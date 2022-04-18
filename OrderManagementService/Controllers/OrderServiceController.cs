using Consul;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using OrderManagementService.Infrastructure;
using OrderManagementService.Models;
using OrderManagementService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace OrderManagementService.Controllers
{
    /// <summary>
    /// Class is responsible for Order related operations like Raise request, cancel request,etc
    /// </summary>
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private static readonly IOrderServiceManagement orderServiceManagement = new OrderServiceManagement();
        private readonly IBusControl _bus;
        private readonly IConfiguration configuration;

        private readonly ILogger _logger;

        private readonly IConsulClient consulClient;

        public OrderServiceController(IBusControl bus, IConfiguration configuration, ILogger<OrderServiceController> logger)
        {
            _bus = bus;
            _logger = logger;
            this.configuration = configuration;

             consulClient = new ConsulClient(config =>
            {
                config.Address = configuration.GetValue<Uri>("ServiceConfig:ServiceDiscoveryAddress");
            });
        }

        /// <summary>
        /// Get method to return all raised service request by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>List of service request details object by consumerId</returns>
        [Route("/order/getAllRaisedServiceRequests/{consumerId}")]
        [HttpGet]
        public List<ServiceRequestDetails> GetAllRaisedServiceRequestsAsync(int consumerId)
        {
            return orderServiceManagement.GetAllRaisedServiceRequests(consumerId);
        }

        /// <summary>
        /// Get method to return raised service request details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        [Route("/order/getRaisedServiceRequestDetails/{requestId}")]
        [HttpGet]
        public ServiceRequestDetails GetRaisedServiceRequestDetails(int requestId)
        {
            return orderServiceManagement.GetRaisedServiceRequestDetails(requestId);
        }

        /// <summary>
        /// Post method to raise the service request by consumer
        /// </summary>
        /// <param name="serviceRequestDetails"></param>
        /// <returns>service request details object</returns>
        [Route("/order/postRaiseServiceRequest")]
        [HttpPost]
        public ServiceRequestDetails PostRaiseServiceRequest([FromBody] ServiceRequestDetails serviceRequestDetails)
        {
            return orderServiceManagement.PostRaiseServiceRequest(serviceRequestDetails);
        }

        /// <summary>
        /// Get method to cancel the raised service request by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        [Route("/order/cancelRaiseServiceRequest/{requestId}")]
        [HttpGet]
        public ServiceRequestDetails CancelRaiseServiceRequest(int requestId)
        {
            return orderServiceManagement.CancelRaiseServiceRequest(requestId);
        }

        /// <summary>
        /// Get method to return service request information by providerId and requestStatus
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="requestStatus"></param>
        /// <returns>List of service request details object</returns>
        [Route("/order/getServiceRequestInfo/{providerId}")]
        [HttpGet]
        public List<ServiceRequestDetails> GetServiceRequestInfo(int providerId, [FromQuery] string requestStatus)
        {
            return orderServiceManagement.GetServiceRequestInfo(providerId, requestStatus);
        }

        /// <summary>
        /// Get method to return all raised request details by status
        /// </summary>
        /// <param name="requestStatus"></param>
        /// <returns>service request details object</returns>
        [Route("/order/getAllRaisedRequestDetailsByStatus/{requestStatus}")]
        [HttpGet]
        public List<ServiceRequestDetails> GetAllRaisedRequestDetailsByStatus(string requestStatus)
        {
            List<ServiceRequestDetails> list = orderServiceManagement.GetAllRaisedRequestDetailsByStatus(requestStatus);
            return list;
        }

        /// <summary>
        /// Get method to return all raised request details by Admin team
        /// </summary>
        /// <returns>List of service request details object</returns>
        [Route("/order/getAllRaisedRequestDetails")]
        [HttpGet]
        public List<ServiceRequestDetails> GetAllRaisedRequestDetails()
        {
            return orderServiceManagement.GetAllRaisedRequestDetails();
        }

        /// <summary>
        /// Get method to Assign provider to service request by requestId and providerId
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="providerId"></param>
        /// <returns>service request details object</returns>
        [Route("/order/assignProviderToServiceRequest")]
        [HttpGet]
        public async Task<ServiceRequestDetails> AssignProviderToServiceRequest([FromQuery] int requestId, [FromQuery] int providerId)
        {
            ServiceRequestDetails serviceRequest = orderServiceManagement.AssignProviderToServiceRequest(requestId, providerId);
            Uri uri = new Uri($"rabbitmq://{configuration.GetValue<string>("RabbitMQHostName")}/orderconfirmation");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(serviceRequest);
            return serviceRequest;
        }

        /// <summary>
        /// Post method to transfer the control to payment service for MakePayment
        /// </summary>
        /// <param name="paymentDetails"></param>
        /// <returns>Payment details object</returns>
        [Route("/order/makePayment")]
        [HttpPost]
        public async Task<PaymentDetails> MakePayment([FromBody] PaymentDetails paymentDetails)
        {
            var client = new HttpClient();
            var serviceURL = await GetRequestUriAsync("PaymentService");
            Uri address = new Uri(serviceURL, $"payment/makePayment");
            string responseData;
            using (var response = await client.PostAsJsonAsync(address, paymentDetails))
            {
                orderServiceManagement.SetPaymentStatusSuccess(paymentDetails.RequestId);
                responseData = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject(responseData, typeof(PaymentDetails)) as PaymentDetails;
        }

        /// <summary>
        /// Get method to return Job Description to provider by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        [Route("/order/getJobDescription/{requestId}")]
        [HttpGet]
        public async Task<JobDescriptionDetails> GetJobDescription(int requestId)
        {
            ServiceRequestDetails requestDetails = orderServiceManagement.GetRaisedServiceRequestDetails(requestId);
            if (requestDetails.ProviderId != 0)
            {
                OnDemandServiceDetails onDemandServiceDetails = await GetServiceDetails(requestDetails.ServiceId);
                ConsumerDetails consumerDetails = await GetConsumerDetails(requestDetails.ConsumerId);

                JobDescriptionDetails jobDescriptionDetails = new JobDescriptionDetails
                {
                    RequestId = requestId,
                    ServiceName = onDemandServiceDetails.ServiceName,
                    PayableAmount = requestDetails.ServiceAmount * 0.8,
                    Date = requestDetails.ServiceDate,
                    ConsumerName = consumerDetails.ConsumerName,
                    Address = consumerDetails.Address,
                    ConsumerMobile = consumerDetails.MobileNumber
                };
                return jobDescriptionDetails;
            }
            return null;
        }

        /// <summary>
        /// Method to get service details from OnDemand service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>OnDemand service details object</returns>
        private async Task<OnDemandServiceDetails> GetServiceDetails(int serviceId)
        {
            var client = new HttpClient();
            var serviceURL = await GetRequestUriAsync("OnDemandService");
            Uri address = new Uri(serviceURL, $"ondemandservice/getServiceDetails/{serviceId}");
            string responseData;
            using (var response = await client.GetAsync(address))
            {
                responseData = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject(responseData, typeof(OnDemandServiceDetails)) as OnDemandServiceDetails;
        }

        /// <summary>
        /// method to return consumer details from consumer service by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>consumer details object</returns>
        private async Task<ConsumerDetails> GetConsumerDetails(int consumerId)
        {
            var client = new HttpClient();
            var serviceURL = await GetRequestUriAsync("ConsumerService");
             Uri address = new Uri(serviceURL, $"consumer/getConsumerDetails/{consumerId}");
             string responseData;
             using (var response = await client.GetAsync(address))
             {
                 responseData = await response.Content.ReadAsStringAsync();
             }
             return JsonConvert.DeserializeObject(responseData, typeof(ConsumerDetails)) as ConsumerDetails;
        }

        private async Task<Uri> GetRequestUriAsync(string serviceName)
        {
            var allRegisteredServices = await consulClient.Agent.Services();
            var registeredServices = allRegisteredServices.Response?.Where(s => s.Value.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToList();
            var service = GetRandomInstance(registeredServices, serviceName);
            var uriBuilder = new UriBuilder()
            {
                Host = service.Address,
                Port = service.Port
            };
            return uriBuilder.Uri;
        }

        private AgentService GetRandomInstance(IList<AgentService> services, string serviceName)
        {
            Random _random = new Random();
            AgentService servToUse = null;
            servToUse = services[_random.Next(0, services.Count)];
            return servToUse;
        }
    }
}

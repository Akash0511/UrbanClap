using AdminService.Infrastructure;
using AdminService.Models;
using AdminService.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AdminService.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static readonly IAdminServiceManagement adminServiceManagement = new AdminServiceManagement();

        private readonly IBusControl _bus;
        private readonly IConfiguration _config;

        public AdminController(IBusControl bus, IConfiguration config)
        {
            _bus = bus;
            _config = config;
        }

        /// <summary>
        /// Post method to Accept or Deny the service request by provider
        /// </summary>
        /// <param name="serviceRequestAcceptance"></param>
        [Route("/admin/serviceRequestAcceptOrDeny")]
        [HttpPost]
        public void ServiceRequestAcceptOrDeny([FromBody] ServiceRequestAcceptance serviceRequestAcceptance)
        {
            adminServiceManagement.ServiceRequestAcceptOrDeny(serviceRequestAcceptance);
        }

        /// <summary>
        /// Get method to return all accepted request by providers corresponding to requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of service request acceptance object</returns>
        [Route("/admin/getAllAcceptedRequestByProviders/{requestId}")]
        [HttpGet]
        public List<ServiceRequestAcceptance> GetAllAcceptedRequestByProviders(int requestId)
        {
            return adminServiceManagement.GetAllAcceptedRequestByProviders(requestId);
        }

        /// <summary>
        /// Post method to send notification to matched providers by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="matchedProviders"></param>
        /// <returns>notification confirmation message</returns>
        [Route("/admin/sendNotificationToMatchedProviders/{requestId}")]
        [HttpPost]
        public async Task<string> SendNotificationToMatchedProviders(int requestId, [FromBody] List<ProviderDetails> matchedProviders)
        {
            adminServiceManagement.AddNotificationDetails(requestId, matchedProviders);
            ProviderNotificationDTO providers = new ProviderNotificationDTO(requestId, matchedProviders);
            Uri uri = new Uri($"rabbitmq://{_config.GetValue<string>("RabbitMQHostName")}/providernotification");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(providers);
            return "Notification sent to all given providers";
        }
    }
}

using Models;
using OrderManagementService.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementService.Services
{
    public class OrderServiceManagement : IOrderServiceManagement
    {
        private static Dictionary<int, ServiceRequestDetails> serviceRequests;
        public OrderServiceManagement()
        {
            serviceRequests = new Dictionary<int, ServiceRequestDetails>
            {
                { 1, new ServiceRequestDetails(1, "pending", 0, 1, 1, "02-03-2021", 2000) },
                { 2, new ServiceRequestDetails(2, "confirmed", 1, 2, 2, "05-03-2021", 1500) },
                { 3, new ServiceRequestDetails(3, "cancelled", 0, 1, 1, "01-04-2021", 350) },
                { 4, new ServiceRequestDetails(3, "completed", 1, 1, 1, "21-03-2021", 8000) }
            };
        }

        /// <summary>
        /// method to return all raised service request by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>List of service request details object by consumerId</returns>
        public List<ServiceRequestDetails> GetAllRaisedServiceRequests(int consumerId)
        {
            List<ServiceRequestDetails> serviceRequestList = serviceRequests.Values.ToList<ServiceRequestDetails>();
            return serviceRequestList.Where(item => item.ConsumerId == consumerId).ToList();
        }

        /// <summary>
        /// method to return raised service request details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        public ServiceRequestDetails GetRaisedServiceRequestDetails(int requestId)
        {
            List<ServiceRequestDetails> serviceRequestList = serviceRequests.Values.ToList<ServiceRequestDetails>();
            return serviceRequestList.Where(item => item.RequestId == requestId).First();
        }

        /// <summary>
        /// method to raise the service request by consumer
        /// </summary>
        /// <param name="serviceRequestDetails"></param>
        /// <returns>service request details object</returns>
        public ServiceRequestDetails PostRaiseServiceRequest(ServiceRequestDetails serviceRequestDetails)
        {
            serviceRequestDetails.RequestId = serviceRequests.Count + 1;
            serviceRequestDetails.RequestStatus = "Open";
            serviceRequests.Add(serviceRequestDetails.RequestId, serviceRequestDetails);
            return serviceRequestDetails;
        }

        /// <summary>
        /// method to cancel the raised service request by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        public ServiceRequestDetails CancelRaiseServiceRequest(int requestId)
        {
            if (serviceRequests.ContainsKey(requestId))
            {
                serviceRequests[requestId].RequestStatus = "cancelled";
                return serviceRequests[requestId];
            }
            return null;
        }

        /// <summary>
        /// method to return service request information by providerId and requestStatus
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="requestStatus"></param>
        /// <returns>List of service request details object</returns>
        public List<ServiceRequestDetails> GetServiceRequestInfo(int providerId, string requestStatus)
        {
            List<ServiceRequestDetails> serviceProvidedList = serviceRequests.Values.ToList<ServiceRequestDetails>();
            return requestStatus == null ? serviceProvidedList.Where(item => item.ProviderId == providerId).ToList()
                                        : serviceProvidedList.Where(item => item.ProviderId == providerId && item.RequestStatus == requestStatus).ToList();
        }

        /// <summary>
        /// method to return all raised request details by status
        /// </summary>
        /// <param name="requestStatus"></param>
        /// <returns>service request details object</returns>
        public List<ServiceRequestDetails> GetAllRaisedRequestDetailsByStatus(string requestStatus)
        {
            List<ServiceRequestDetails> raisedServiceList = serviceRequests.Values.ToList<ServiceRequestDetails>();
            raisedServiceList = raisedServiceList.Where(item => item.RequestStatus == requestStatus).ToList();
            return raisedServiceList;
        }

        /// <summary>
        /// method to return all raised request details by Admin team
        /// </summary>
        /// <returns>List of service request details object</returns>
        public List<ServiceRequestDetails> GetAllRaisedRequestDetails()
        {
            return serviceRequests.Values.ToList<ServiceRequestDetails>();
        }

        /// <summary>
        /// method to Assign provider to service request by requestId and providerId
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="providerId"></param>
        /// <returns>service request details object</returns>
        public ServiceRequestDetails AssignProviderToServiceRequest(int requestId, int providerId)
        {
            if (serviceRequests.ContainsKey(requestId))
            {
                serviceRequests[requestId].ProviderId = providerId;
                serviceRequests[requestId].RequestStatus = "confirmed";
                return serviceRequests[requestId];
            }
            return null;
        }

        /// <summary>
        /// method to change request status to completed after payment being made
        /// </summary>
        /// <param name="requestId"></param>
        public void SetPaymentStatusSuccess(int requestId)
        {
            serviceRequests[requestId].RequestStatus = "completed";
        }
    }
}

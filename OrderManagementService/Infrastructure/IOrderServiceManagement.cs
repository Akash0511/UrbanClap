using Models;
using System.Collections.Generic;

namespace OrderManagementService.Infrastructure
{
    interface IOrderServiceManagement
    {
        //For consumer

        /// <summary>
        /// method to return all raised service request by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>List of service request details object by consumerId</returns>
        List<ServiceRequestDetails> GetAllRaisedServiceRequests(int consumerId);

        /// <summary>
        /// method to return raised service request details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        ServiceRequestDetails GetRaisedServiceRequestDetails(int requestId);

        /// <summary>
        /// method to raise the service request by consumer
        /// </summary>
        /// <param name="serviceRequestDetails"></param>
        /// <returns>service request details object</returns>
        ServiceRequestDetails PostRaiseServiceRequest(ServiceRequestDetails serviceRequestDetails);

        /// <summary>
        /// method to cancel the raised service request by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>service request details object</returns>
        ServiceRequestDetails CancelRaiseServiceRequest(int requestId);

        //For provider

        /// <summary>
        /// method to return service request information by providerId and requestStatus
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="requestStatus"></param>
        /// <returns>List of service request details object</returns>
        List<ServiceRequestDetails> GetServiceRequestInfo(int providerId, string requestStatus);

        //For admin

        /// <summary>
        /// method to return all raised request details by status
        /// </summary>
        /// <param name="requestStatus"></param>
        /// <returns>service request details object</returns>
        List<ServiceRequestDetails> GetAllRaisedRequestDetailsByStatus(string requestStatus);

        /// <summary>
        /// method to return all raised request details by Admin team
        /// </summary>
        /// <returns>List of service request details object</returns>
        List<ServiceRequestDetails> GetAllRaisedRequestDetails();

        /// <summary>
        /// method to Assign provider to service request by requestId and providerId
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="providerId"></param>
        /// <returns>service request details object</returns>
        ServiceRequestDetails AssignProviderToServiceRequest(int requestId, int providerId);

        /// <summary>
        /// method to change request status to completed after payment being made
        /// </summary>
        /// <param name="requestId"></param>
        void SetPaymentStatusSuccess(int requestId);
    }
}

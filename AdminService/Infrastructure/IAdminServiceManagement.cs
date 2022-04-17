using AdminService.Models;
using System.Collections.Generic;

namespace AdminService.Infrastructure
{
    interface IAdminServiceManagement
    {
        /// <summary>
        /// method to add the notification details
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="matchedProviders"></param>
        void AddNotificationDetails(int requestId, List<ProviderDetails> matchedProviders);

        /// <summary>
        /// method to Accept or Deny the service request by provider
        /// </summary>
        /// <param name="serviceRequestAcceptance"></param>
        void ServiceRequestAcceptOrDeny(ServiceRequestAcceptance serviceRequestAcceptance);

        /// <summary>
        /// method to return all accepted request by providers corresponding to requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of service request acceptance object</returns>
        List<ServiceRequestAcceptance> GetAllAcceptedRequestByProviders(int requestId);
    }
}

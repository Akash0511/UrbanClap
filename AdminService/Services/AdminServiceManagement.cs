using AdminService.DataAccess;
using AdminService.Infrastructure;
using AdminService.Models;
using System.Collections.Generic;

namespace AdminService.Services
{
    public class AdminServiceManagement : IAdminServiceManagement
    {
        private static readonly ServiceRequestAcceptanceDAO serviceRequestAcceptanceDAO = new ServiceRequestAcceptanceDAO();

        /// <summary>
        /// method to add the notification details
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="matchedProviders"></param>
        public void AddNotificationDetails(int requestId, List<ProviderDetails> matchedProviders)
        {
            serviceRequestAcceptanceDAO.AddNotificationDetails(requestId, matchedProviders);
        }

        /// <summary>
        /// method to Accept or Deny the service request by provider
        /// </summary>
        /// <param name="serviceRequestAcceptance"></param>
        public void ServiceRequestAcceptOrDeny(ServiceRequestAcceptance serviceRequestAcceptance)
        {
            serviceRequestAcceptanceDAO.ServiceRequestAcceptOrDeny(serviceRequestAcceptance);
        }

        /// <summary>
        /// method to return all accepted request by providers corresponding to requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of service request acceptance object</returns>
        public List<ServiceRequestAcceptance> GetAllAcceptedRequestByProviders(int requestId)
        {
            return serviceRequestAcceptanceDAO.GetAllAcceptedRequestByProviders(requestId);
        }
    }
}

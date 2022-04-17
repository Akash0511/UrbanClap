using AdminService.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdminService.DataAccess
{
    public class ServiceRequestAcceptanceDAO
    {
        private static List<ServiceRequestAcceptance> serviceRequestAcceptanceData;
        public ServiceRequestAcceptanceDAO()
        {
            serviceRequestAcceptanceData = new List<ServiceRequestAcceptance>
            {
                { new ServiceRequestAcceptance(1, 1, true) },
                { new ServiceRequestAcceptance(2, 2, false) },
                { new ServiceRequestAcceptance(3, 2, true) }
            };

        }

        public void AddNotificationDetails(int requestId, List<ProviderDetails> matchedProviders)
        {
            foreach (var provider in matchedProviders)
            {
                serviceRequestAcceptanceData.Add(new ServiceRequestAcceptance(requestId, provider.ProviderId, false));
            }
        }

        public void ServiceRequestAcceptOrDeny(ServiceRequestAcceptance serviceRequestAcceptance)
        {
            if (serviceRequestAcceptance.IsAccepted)
            {
                int index = serviceRequestAcceptanceData.FindIndex(x => x.RequestId == serviceRequestAcceptance.RequestId && x.ProviderId == serviceRequestAcceptance.ProviderId);
                if(index != -1)
                {
                    serviceRequestAcceptanceData[index].IsAccepted = true;
                }
                
            }
            
        }

        public List<ServiceRequestAcceptance> GetAllAcceptedRequestByProviders(int requestId)
        {
            return serviceRequestAcceptanceData.Where(x => x.IsAccepted && x.RequestId == requestId).ToList();
        }
    }
}

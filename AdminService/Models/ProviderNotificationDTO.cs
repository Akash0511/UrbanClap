using AdminService.Models;
using System.Collections.Generic;

namespace Models
{
    public class ProviderNotificationDTO
    {
        public ProviderNotificationDTO()
        {
        }

        public ProviderNotificationDTO(int requestId, List<ProviderDetails> providers)
        {
            RequestId = requestId;
            Providers = providers;
        }

        public int RequestId { get; set; }
        public List<ProviderDetails> Providers { get; set; }
    }
}

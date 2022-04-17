using System.ComponentModel.DataAnnotations;

namespace AdminService.Models
{
    public class ServiceRequestAcceptance
    {
        public ServiceRequestAcceptance()
        {
        }
        public ServiceRequestAcceptance(int providerId, int requestId, bool isAccepted)
        {
            ProviderId = providerId;
            RequestId = requestId;
            IsAccepted = isAccepted;
        }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        public int RequestId { get; set; }

        public bool IsAccepted { get; set; }
    }
}

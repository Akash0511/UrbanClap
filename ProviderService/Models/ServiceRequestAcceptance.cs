using System.ComponentModel.DataAnnotations;

namespace ProviderService.Models
{
    public class ServiceRequestAcceptance
    {
        [Required]
        public int ProviderId { get; set; }

        [Required]
        public int RequestId { get; set; }

        [Required]
        public bool IsAccepted { get; set; }
    }
}

namespace AdminService.Models
{
    public class ProviderDetails
    {
        public ProviderDetails()
        {
        }
        public ProviderDetails(int providerId, string providerName, string mobileNumber, string email, int locationId, bool isAvailable, int serviceId)
        {
            ProviderId = providerId;
            ProviderName = providerName;
            MobileNumber = mobileNumber;
            Email = email;
            LocationId = locationId;
            IsAvailable = isAvailable;
            ServiceId = serviceId;
        }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
        public bool IsAvailable { get; set; }
        public int ServiceId { get; set; }
    }
}

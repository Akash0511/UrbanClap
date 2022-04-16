namespace ConsumerService.Models
{
    public class ServiceRequestDetails
    {
        public ServiceRequestDetails()
        {
        }
        public ServiceRequestDetails(int requestId, string requestStatus, int providerId, int consumerId, int serviceId)
        {
            RequestId = requestId;
            RequestStatus = requestStatus;
            ProviderId = providerId;
            ConsumerId = consumerId;
            ServiceId = serviceId;
        }

        public int RequestId { get; set; }
        public string RequestStatus { get; set; }
        public int ProviderId { get; set; }
        public int ConsumerId { get; set; }
        public int ServiceId { get; set; }
    }
}

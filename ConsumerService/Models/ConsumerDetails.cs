namespace ConsumerService.Models
{
    public class ConsumerDetails
    {
        public ConsumerDetails()
        {
        }
        public ConsumerDetails(int consumerId, string consumerName, string mobileNumber, string email, int locationId, string address)
        {
            ConsumerId = consumerId;
            ConsumerName = consumerName;
            MobileNumber = mobileNumber;
            Email = email;
            LocationId = locationId;
            Address = address;
        }

        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
    }
}

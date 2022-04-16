namespace OnDemandService.Models
{
    public class LocationDetails
    {
        public LocationDetails()
        {
        }
        public LocationDetails(int locationId, string locationName, int pinCode)
        {
            LocationId = locationId;
            LocationName = locationName;
            PinCode = pinCode;
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int PinCode { get; set; }
    }
}

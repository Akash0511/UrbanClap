using OnDemandService.Infrastructure;
using OnDemandService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnDemandService.Services
{
    public class LocationManagement : ILocationManagement
    {
        private static Dictionary<int, LocationDetails> locations;
        public LocationManagement()
        {
            locations = new Dictionary<int, LocationDetails>
            {
                { 1, new LocationDetails(1, "Rohini", 110086) },
                { 2, new LocationDetails(2, "Tilak Nagar", 110041) },
                { 3, new LocationDetails(3, "Gurugram", 200456) }
            };
        }

        /// <summary>
        /// Post method to add new location in the system
        /// </summary>
        /// <param name="locationDetails"></param>
        /// <returns>Location Details</returns>
        public LocationDetails AddLocation(LocationDetails locationDetails)
        {
            locationDetails.LocationId = locations.Count + 1;
            locations.Add(locationDetails.LocationId, locationDetails);
            return locationDetails;
        }

        /// <summary>
        /// method to return List of Location Details
        /// </summary>
        /// <returns>List of location Details</returns>
        public List<LocationDetails> GetAllLocation()
        {
            return locations.Values.ToList<LocationDetails>();
        }
    }
}

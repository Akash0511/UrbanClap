using OnDemandService.Models;
using System.Collections.Generic;

namespace OnDemandService.Infrastructure
{
    interface ILocationManagement
    {
        /// <summary>
        /// Post method to add new location in the system
        /// </summary>
        /// <param name="locationDetails"></param>
        /// <returns>Location Details</returns>
        LocationDetails AddLocation(LocationDetails locationDetails);

        /// <summary>
        /// method to return List of Location Details
        /// </summary>
        /// <returns>List of location Details</returns>
        List<LocationDetails> GetAllLocation();
    }
}

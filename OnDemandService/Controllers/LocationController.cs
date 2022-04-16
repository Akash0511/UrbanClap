using Microsoft.AspNetCore.Mvc;
using OnDemandService.Infrastructure;
using OnDemandService.Models;
using OnDemandService.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnDemandService.Controllers
{
    /// <summary>
    /// Class is responsible for add new location, get all locations
    /// </summary>
    [ApiController]
    public class LocationController : ControllerBase
    {
        private static readonly ILocationManagement locationManagement = new LocationManagement();

        /// <summary>
        /// Post method to add new location in the system
        /// </summary>
        /// <param name="locationDetails"></param>
        /// <returns>Location Details</returns>
        [Route("/location/addLocation")]
        [HttpPost]
        public ActionResult<LocationDetails> AddLocation([FromBody] LocationDetails locationDetails)
        {
            return locationManagement.AddLocation(locationDetails);
        }

        /// <summary>
        /// Get method to return List of Location Details
        /// </summary>
        /// <returns>List of location Details</returns>
        [Route("/location/getAllLocation")]
        [HttpGet]
        public List<LocationDetails> GetAllLocation()
        {
            return locationManagement.GetAllLocation();
        }
    }
}

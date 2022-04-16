using Microsoft.AspNetCore.Mvc;
using OnDemandService.Infrastructure;
using OnDemandService.Models;
using OnDemandService.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnDemandService.Controllers
{
    /// <summary>
    /// Class is responsible to manage offered Services that include Adding of new service,
    /// activate or deactivate services, etc
    /// </summary>
    [ApiController]
    public class OnDemandServiceController : ControllerBase
    {
        private static readonly IServiceManagement serviceManagement = new ServiceManagement();

        /// <summary>
        /// Post method to Add new service
        /// </summary>
        /// <param name="serviceDetails"></param>
        /// <returns>On Demand service details object</returns>
        [Route("/ondemandservice/addService")]
        [HttpPost]
        public ActionResult<OnDemandServiceDetails> AddService([FromBody] OnDemandServiceDetails serviceDetails)
        {
            return serviceManagement.AddService(serviceDetails);
        }

        /// <summary>
        /// Put method that Activate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        [Route("/ondemandservice/activateService/{serviceID}")]
        [HttpPut]
        public OnDemandServiceDetails ActivateService(int serviceID)
        {
            return serviceManagement.ActivateService(serviceID);
        }

        /// <summary>
        /// Put method that Deactivate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        [Route("/ondemandservice/deactivateService/{serviceID}")]
        [HttpPut]
        public OnDemandServiceDetails DeactivateService(int serviceID)
        {
            return serviceManagement.DeactivateService(serviceID);
        }

        /// <summary>
        /// Get method to return all services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        [Route("/ondemandservice/getAllServicesByLocation/{locationId}")]
        [HttpGet]
        public List<OnDemandServiceDetails> GetAllServicesByLocation(int locationId)
        {
            return serviceManagement.GetAllServicesByLocation(locationId);
        }

        /// <summary>
        /// Get method to return available services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        [Route("/ondemandservice/getAvailableServicesByLocation/{locationId}")]
        [HttpGet]
        public List<OnDemandServiceDetails> GetAvailableServicesList(int locationId)
        {
            return serviceManagement.GetAvailableServicesList(locationId);
        }

        /// <summary>
        /// Get method to return service details by serviceId
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>On Demand service details object</returns>
        [Route("/ondemandservice/getServiceDetails/{serviceId}")]
        [HttpGet]
        public OnDemandServiceDetails GetServiceDetails(int serviceId)
        {
            return serviceManagement.GetServiceDetails(serviceId);
        }
    }
}

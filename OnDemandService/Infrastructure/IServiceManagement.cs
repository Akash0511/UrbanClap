using OnDemandService.Models;
using System.Collections.Generic;

namespace OnDemandService.Infrastructure
{
    interface IServiceManagement
    {
        /// <summary>
        /// method to Add new service
        /// </summary>
        /// <param name="serviceDetails"></param>
        /// <returns>On Demand service details object</returns>
        OnDemandServiceDetails AddService(OnDemandServiceDetails serviceDetails);

        /// <summary>
        /// method that Activate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        OnDemandServiceDetails ActivateService(int serviceId);

        /// <summary>
        /// method that Deactivate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        OnDemandServiceDetails DeactivateService(int serviceId);

        /// <summary>
        /// method to return all services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        List<OnDemandServiceDetails> GetAllServicesByLocation(int locationId);

        /// <summary>
        /// method to return available services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        List<OnDemandServiceDetails> GetAvailableServicesList(int locationId);

        /// <summary>
        /// method to return service details by serviceId
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>On Demand service details object</returns>
        OnDemandServiceDetails GetServiceDetails(int serviceId);
    }
}

using OnDemandService.Infrastructure;
using OnDemandService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnDemandService.Services
{
    public class ServiceManagement : IServiceManagement
    {
        private static Dictionary<int, OnDemandServiceDetails> services;
        public ServiceManagement()
        {
            services = new Dictionary<int, OnDemandServiceDetails>
            {
                { 1, new OnDemandServiceDetails(1, "Electrician", true, 1) },
                { 2, new OnDemandServiceDetails(2, "Yoga Trainer", true, 2) },
                { 3, new OnDemandServiceDetails(3, "Interior Designer", true, 1) }
            };
        }

        /// <summary>
        /// method that Activate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        public OnDemandServiceDetails ActivateService(int serviceId)
        {
            OnDemandServiceDetails serviceDetails = services.GetValueOrDefault(serviceId);
            if (serviceDetails != null && serviceDetails.IsActivated != true)
            {
                serviceDetails.IsActivated = true;
                services[serviceId] = serviceDetails;
            }
            return serviceDetails;
        }

        /// <summary>
        /// method to Add new service
        /// </summary>
        /// <param name="serviceDetails"></param>
        /// <returns>On Demand service details object</returns>
        public OnDemandServiceDetails AddService(OnDemandServiceDetails serviceDetails)
        {
            serviceDetails.ServiceID = services.Count + 1;
            serviceDetails.IsActivated = true;
            services.Add(serviceDetails.ServiceID, serviceDetails);
            return serviceDetails;
        }

        /// <summary>
        /// method that Deactivate the existing service
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns>On Demand service details object</returns>
        public OnDemandServiceDetails DeactivateService(int serviceId)
        {
            OnDemandServiceDetails serviceDetails = services.GetValueOrDefault(serviceId);
            if (serviceDetails != null && serviceDetails.IsActivated)
            {
                serviceDetails.IsActivated = false;
                services[serviceId] = serviceDetails;
            }
            return serviceDetails;
        }

        /// <summary>
        /// method to return all services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        public List<OnDemandServiceDetails> GetAllServicesByLocation(int locationId)
        {
            List<OnDemandServiceDetails> serviceList = services.Values.ToList<OnDemandServiceDetails>();
            return serviceList.Where(item => item.LocationId == locationId).ToList();
        }

        /// <summary>
        /// method to return available services by location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>List of On Demand service details object</returns>
        public List<OnDemandServiceDetails> GetAvailableServicesList(int locationId)
        {
            List<OnDemandServiceDetails> serviceList = services.Values.ToList<OnDemandServiceDetails>();
            return serviceList.Where(item => item.LocationId == locationId && item.IsActivated).ToList();
        }

        /// <summary>
        /// method to return service details by serviceId
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>On Demand service details object</returns>
        public OnDemandServiceDetails GetServiceDetails(int serviceId)
        {
            return services[serviceId];
        }
    }
}

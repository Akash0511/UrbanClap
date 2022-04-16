using ProviderService.DataAccess;
using ProviderService.Infrastructure;
using ProviderService.Models;
using System.Collections.Generic;

namespace ProviderService.Services
{
    public class ProviderServiceManagement : IProviderServiceManagement
    {
        private static readonly ProviderDAO providerDAO = new ProviderDAO();

        /// <summary>
        /// Post method that register provider
        /// </summary>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails RegisterProvider(ProviderDetails providerDetails)
        {
            return providerDAO.AddProvider(providerDetails);
        }

        /// <summary>
        /// Put method that is responsible for editing of the profile of provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails EditProviderProfile(int providerId, ProviderDetails providerDetails)
        {
            return providerDAO.EditProviderProfile(providerId, providerDetails);
        }

        /// <summary>
        /// Get method to return provider details by providerId
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails GetProviderDetails(int providerId)
        {
            return providerDAO.GetProviderDetails(providerId);
        }

        /// <summary>
        /// method to return all available providers by locationId and serviceId
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="serviceId"></param>
        /// <returns>List of Provider object</returns>
        public List<ProviderDetails> GetAllAvailableProviderDetails(int locationId, int serviceId)
        {
            return providerDAO.GetAllAvailableProviderDetails(locationId, serviceId);
        }
    }
}

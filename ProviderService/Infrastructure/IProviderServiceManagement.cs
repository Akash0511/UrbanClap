using ProviderService.Models;
using System.Collections.Generic;

namespace ProviderService.Infrastructure
{
    interface IProviderServiceManagement
    {
        /// <summary>
        /// Post method that register provider
        /// </summary>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        ProviderDetails RegisterProvider(ProviderDetails providerDetails);

        /// <summary>
        /// Put method that is responsible for editing of the profile of provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        ProviderDetails EditProviderProfile(int providerId, ProviderDetails providerDetails);

        /// <summary>
        /// Get method to return provider details by providerId
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns>Provider object</returns>
        ProviderDetails GetProviderDetails(int providerId);

        /// <summary>
        /// method to return all available providers by locationId and serviceId
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="serviceId"></param>
        /// <returns>List of Provider object</returns>
        List<ProviderDetails> GetAllAvailableProviderDetails(int locationId, int serviceId);
    }
}

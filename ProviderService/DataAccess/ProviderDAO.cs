using ProviderService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProviderService.DataAccess
{
    public class ProviderDAO
    {
        private static Dictionary<int, ProviderDetails> providersData;
        public ProviderDAO()
        {
            providersData = new Dictionary<int, ProviderDetails>
            {
                { 1, new ProviderDetails(1, "Surya","9678437890", "surya@gmail.com", 2, true, 1) },
                { 2, new ProviderDetails(2, "Rama", "8000437890", "rama@gmail.com", 1, true, 2) },
                { 3, new ProviderDetails(3, "Balraj", "7432437890", "balraj@gmail.com", 2, false, 1) }
            };
        }

        /// <summary>
        /// Post method that register provider
        /// </summary>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails AddProvider(ProviderDetails providerDetails)
        {
            providerDetails.ProviderId = providersData.Count + 1;
            providersData.Add(providerDetails.ProviderId, providerDetails);
            return providerDetails;
        }

        /// <summary>
        /// Put method that is responsible for editing of the profile of provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails EditProviderProfile(int providerId, ProviderDetails providerDetails)
        {
            if (providersData.ContainsKey(providerId))
            {
                providersData[providerId] = providerDetails;
                return providerDetails;
            }
            return null;
        }

        /// <summary>
        /// Get method to return provider details by providerId
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns>Provider object</returns>
        public ProviderDetails GetProviderDetails(int providerId)
        {
            List<ProviderDetails> providers = providersData.Values.ToList<ProviderDetails>();
            return providers.Where(item => item.ProviderId == providerId).FirstOrDefault();
        }

        /// <summary>
        /// method to return all available providers by locationId and serviceId
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="serviceId"></param>
        /// <returns>List of Provider object</returns>
        public List<ProviderDetails> GetAllAvailableProviderDetails(int locationId, int serviceId)
        {
            List<ProviderDetails> providers = providersData.Values.ToList<ProviderDetails>();
            return providers.Where(item => item.LocationId == locationId
                                    && item.ServiceId == serviceId
                                    && item.IsAvailable).ToList<ProviderDetails>();
        }
    }
}

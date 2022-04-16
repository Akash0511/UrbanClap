using Microsoft.AspNetCore.Mvc;
using ProviderService.Infrastructure;
using ProviderService.Models;
using ProviderService.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProviderService.Controllers
{
    /// <summary>
    /// Class is responsible for Provider related operations like registration, editProfile,
    /// get Provider details,etc
    /// </summary>
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderServiceManagement providerServiceManagement = new ProviderServiceManagement();

        /// <summary>
        /// Post method that register provider
        /// </summary>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        [Route("/provider/register")]
        [HttpPost]
        public ProviderDetails RegisterProvider([FromBody] ProviderDetails providerDetails)
        {
            return providerServiceManagement.RegisterProvider(providerDetails);
        }

        /// <summary>
        /// Put method that is responsible for editing of the profile of provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="providerDetails"></param>
        /// <returns>Provider object</returns>
        [Route("/provider/editProfile/{providerId}")]
        [HttpPut]
        public ProviderDetails EditProviderProfile(int providerId, [FromBody] ProviderDetails providerDetails)
        {
            return providerServiceManagement.EditProviderProfile(providerId, providerDetails);
        }

        /// <summary>
        /// Get method to return provider details by providerId
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns>Provider object</returns>
        [Route("/provider/getProviderDetails/{providerId}")]
        [HttpGet]
        public ProviderDetails GetProviderDetails(int providerId)
        {
            return providerServiceManagement.GetProviderDetails(providerId);
        }

        /// <summary>
        /// Get method to return all available providers by locationId and serviceId
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="serviceId"></param>
        /// <returns>List of Provider object</returns>
        [Route("/provider/getAllAvailableProviderDetails/{locationId}")]
        [HttpGet]
        public List<ProviderDetails> GetAllAvailableProviderDetails(int locationId, [FromQuery] int serviceId)
        {
            return providerServiceManagement.GetAllAvailableProviderDetails(locationId, serviceId);
        }
    }
}

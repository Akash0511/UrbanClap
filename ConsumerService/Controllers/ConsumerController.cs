using ConsumerService.Infrastructure;
using ConsumerService.Models;
using ConsumerService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ConsumerService.Controllers
{
    /// <summary>
    /// Class manages consumer related data like registeration, editprofile,
    /// getConsumerDetails,etc
    /// </summary>
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private static readonly IConsumerServiceManagement consumerServiceManagement = new ConsumerServiceManagement();

        /// <summary>
        /// Post method that register consumer
        /// </summary>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        [Route("/consumer/register")]
        [HttpPost]
        public ActionResult<ConsumerDetails> RegisterConsumer([FromBody] ConsumerDetails consumerDetails)
        {
            return consumerServiceManagement.RegisterConsumer(consumerDetails);
        }

        /// <summary>
        /// Put method that is responsible for editing of the profile of consumer
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        [Route("/consumer/editProfile/{consumerId}")]
        [HttpPut]
        public ConsumerDetails EditConsumerProfile(int consumerId, [FromBody] ConsumerDetails consumerDetails)
        {
            return consumerServiceManagement.EditConsumerProfile(consumerId, consumerDetails);
        }

        /// <summary>
        /// Get method to return consumer details by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>consumer object</returns>
        [Route("/consumer/getConsumerDetails/{consumerId}")]
        [HttpGet]
        public ConsumerDetails GetConsumerDetails(int consumerId)
        {
            return consumerServiceManagement.GetConsumerDetails(consumerId);
        }
    }
}

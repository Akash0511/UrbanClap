using ConsumerService.DataAccess;
using ConsumerService.Infrastructure;
using ConsumerService.Models;

namespace ConsumerService.Services
{
    public class ConsumerServiceManagement : IConsumerServiceManagement
    {
        private static readonly ConsumerDAO consumerDAO = new ConsumerDAO();

        /// <summary>
        /// method that register consumer
        /// </summary>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails RegisterConsumer(ConsumerDetails consumerDetails)
        {
            return consumerDAO.AddConsumer(consumerDetails);
        }

        /// <summary>
        /// method that is responsible for editing of the profile of consumer
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails EditConsumerProfile(int consumerId, ConsumerDetails consumerDetails)
        {
            return consumerDAO.EditConsumerProfile(consumerId, consumerDetails);
        }

        /// <summary>
        /// method to return consumer details by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails GetConsumerDetails(int consumerId)
        {
            return consumerDAO.GetConsumerDetails(consumerId);
        }
    }
}

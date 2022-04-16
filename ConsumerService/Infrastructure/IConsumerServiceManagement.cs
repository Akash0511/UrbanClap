using ConsumerService.Models;

namespace ConsumerService.Infrastructure
{
    interface IConsumerServiceManagement
    {
        /// <summary>
        /// method that register consumer
        /// </summary>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        ConsumerDetails RegisterConsumer(ConsumerDetails consumerDetails);

        /// <summary>
        /// method that is responsible for editing of the profile of consumer
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        ConsumerDetails EditConsumerProfile(int consumerId, ConsumerDetails consumerDetails);

        /// <summary>
        /// method to return consumer details by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>consumer object</returns>
        ConsumerDetails GetConsumerDetails(int consumerId);
    }
}

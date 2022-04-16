using ConsumerService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsumerService.DataAccess
{
    public class ConsumerDAO
    {
        private static Dictionary<int, ConsumerDetails> consumersData;
        public ConsumerDAO()
        {
            consumersData = new Dictionary<int, ConsumerDetails>
            {
                { 1, new ConsumerDetails(1, "Aditya","8765437890", "aditya@gmail.com", 2, "Rohini") },
                { 2, new ConsumerDetails(2, "Saurav", "9765437890", "saurav@gmail.com", 1, "Keshav Puram") },
                { 3, new ConsumerDetails(3, "Ganesh", "7765437890", "ganesh@gmail.com", 3, "Race Course") }
            };
        }

        /// <summary>
        /// method that register consumer
        /// </summary>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails AddConsumer(ConsumerDetails consumerDetails)
        {
            consumerDetails.ConsumerId = consumersData.Count + 1;
            consumersData.Add(consumerDetails.ConsumerId, consumerDetails);
            return consumerDetails;
        }

        /// <summary>
        /// method that is responsible for editing of the profile of consumer
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="consumerDetails"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails EditConsumerProfile(int consumerId, ConsumerDetails consumerDetails)
        {
            if (consumersData.ContainsKey(consumerId))
            {
                consumersData[consumerId] = consumerDetails;
                return consumerDetails;
            }
            return null;
        }

        /// <summary>
        /// method to return consumer details by consumerId
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns>consumer object</returns>
        public ConsumerDetails GetConsumerDetails(int consumerId)
        {
            List<ConsumerDetails> consumers = consumersData.Values.ToList<ConsumerDetails>();
            return consumers.Where(item => item.ConsumerId == consumerId).FirstOrDefault();
        }

    }
}

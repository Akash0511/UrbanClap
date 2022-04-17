using MassTransit;
using Models;
using Nancy.Json;
using System;
using System.Threading.Tasks;

namespace NotificationService
{
    [Serializable]
    public class OrderConfirmationConsumer : IConsumer<ServiceRequestDetails>
    {
        public static string received;

        /// <summary>
        /// To consume the service request details (booking confirmation) for notification from Order management service
        /// </summary>
        /// <param name="context"></param>
        public async Task Consume(ConsumeContext<ServiceRequestDetails> context)
        {
            var receivedmessage = ((MassTransit.Context.ConsumeContextScope<ServiceRequestDetails>)context).Message;
            JavaScriptSerializer js = new JavaScriptSerializer();
            received = js.Serialize(receivedmessage);
        }
    }
}

using MassTransit;
using Models;
using Nancy.Json;
using System.Threading.Tasks;

namespace NotificationService
{
    public class ProviderNotificationConsumer : IConsumer<ProviderNotificationDTO>
    {
        public static string received;

        /// <summary>
        /// To consume the Providers list for notification from Admin
        /// </summary>
        /// <param name="context"></param>
        public async Task Consume(ConsumeContext<ProviderNotificationDTO> context)
        {
            var receivedmessage = ((MassTransit.Context.ConsumeContextScope<ProviderNotificationDTO>)context).Message;
            JavaScriptSerializer js = new JavaScriptSerializer();
            received = js.Serialize(receivedmessage);
        }

    }
}

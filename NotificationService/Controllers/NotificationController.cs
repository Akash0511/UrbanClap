using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationService.Controllers
{
    /// <summary>
    /// Class is responsible to manage notifications
    /// </summary>
    [ApiController]
    public class NotificationController : ControllerBase
    {

        /// <summary>
        /// Get method to return Order confirmation notification
        /// </summary>
        /// <returns>received data from Queue(order confirmation)</returns>
        [Route("/notification/getOrderConfirmationNotification")]
        [HttpGet]
        public ActionResult<string> GetOrderConfirmationNotification()
        {
            return OrderConfirmationConsumer.received;
        }

        /// <summary>
        /// Get method to return provider notification
        /// </summary>
        /// <returns>received data from Queue(Provider)</returns>
        [Route("/notification/getProviderNotification")]
        [HttpGet]
        public ActionResult<string> GetProviderNotification()
        {
            return ProviderNotificationConsumer.received;
        }
    }
}

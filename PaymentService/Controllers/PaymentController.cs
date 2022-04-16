using Microsoft.AspNetCore.Mvc;
using PaymentService.Infrastructure;
using PaymentService.Models;
using PaymentService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentService.Controllers
{
    /// <summary>
    /// Class is responsible to handle payment related operations like make payment, get payment details.
    /// </summary>
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceManagement paymentServiceManagement = new PaymentServiceManagement();

        /// <summary>
        /// Post method to make the payment
        /// </summary>
        /// <param name="paymentDetails"></param>
        /// <returns>Payment details object</returns>
        [Route("/payment/makePayment")]
        [HttpPost]
        public PaymentDetails MakePayment([FromBody] PaymentDetails paymentDetails)
        {
            return paymentServiceManagement.MakePayment(paymentDetails);
        }

        /// <summary>
        /// Get method to return payment details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>Payment details object</returns>
        [Route("/payment/getPaymentDetailsByRequestId/{requestId}")]
        [HttpGet]
        public PaymentDetails GetPaymentDetailsByRequestId(int requestId)
        {
            return paymentServiceManagement.GetPaymentDetailsByRequestId(requestId);
        }
    }
}

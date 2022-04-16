using PaymentService.Models;

namespace PaymentService.Infrastructure
{
    interface IPaymentServiceManagement
    {
        /// <summary>
        /// method to make the payment
        /// </summary>
        /// <param name="paymentDetails"></param>
        /// <returns>Payment details object</returns>
        PaymentDetails MakePayment(PaymentDetails paymentDetails);

        /// <summary>
        /// method to return payment details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>Payment details object</returns>
        PaymentDetails GetPaymentDetailsByRequestId(int requestId);
    }
}

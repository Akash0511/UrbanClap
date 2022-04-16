using PaymentService.Infrastructure;
using PaymentService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PaymentService.Services
{
    public class PaymentServiceManagement : IPaymentServiceManagement
    {
        private readonly Dictionary<int, PaymentDetails> paymentDetailsList = new Dictionary<int, PaymentDetails>();

        /// <summary>
        /// method to make the payment
        /// </summary>
        /// <param name="paymentDetails"></param>
        /// <returns>Payment details object</returns>
        public PaymentDetails MakePayment(PaymentDetails paymentDetails)
        {
            paymentDetails.PaymentId = paymentDetailsList.Count + 1;
            paymentDetails.PaymentStatus = "success";
            paymentDetailsList.Add(paymentDetails.PaymentId, paymentDetails);
            return paymentDetails;
        }

        /// <summary>
        /// method to return payment details by requestId
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>Payment details object</returns>
        public PaymentDetails GetPaymentDetailsByRequestId(int requestId)
        {
            return paymentDetailsList.Values.Where(item => item.RequestId == requestId).FirstOrDefault();
        }
    }
}

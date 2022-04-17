using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementService.Models
{
    public class PaymentDetails
    {
        public int PaymentId { get; set; }
        public int RequestId { get; set; }
        public int ConsumerId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public double Amount { get; set; }
    }
}

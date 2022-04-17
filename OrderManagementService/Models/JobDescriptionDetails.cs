using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementService.Models
{
    public class JobDescriptionDetails
    {
        public int RequestId { get; set; }
        public string ServiceName { get; set; }
        public double PayableAmount { get; set; }
        public string Date { get; set; }
        public string ConsumerName { get; set; }
        public string Address { get; set; }
        public string ConsumerMobile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ServiceRequestDetails
    {
        public ServiceRequestDetails()
        {
        }
        public ServiceRequestDetails(int requestId, string requestStatus, int providerId, int consumerId, int serviceId, string serviceDate, double serviceAmount)
        {
            RequestId = requestId;
            RequestStatus = requestStatus;
            ProviderId = providerId;
            ConsumerId = consumerId;
            ServiceId = serviceId;
            ServiceDate = serviceDate;
            ServiceAmount = serviceAmount;
        }

        public int RequestId { get; set; }
        public string RequestStatus { get; set; }
        public int ProviderId { get; set; }
        public int ConsumerId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceDate { get; set; }
        public double ServiceAmount { get; set; }
    }
}

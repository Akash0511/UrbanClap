using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementService.Models
{
    public class OnDemandServiceDetails
    {
        public OnDemandServiceDetails()
        {
        }
        public OnDemandServiceDetails(int serviceID, string serviceName, bool isActivated, int locationId)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            IsActivated = isActivated;
            LocationId = locationId;
        }

        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool IsActivated { get; set; }
        public int LocationId { get; set; }
    }
}

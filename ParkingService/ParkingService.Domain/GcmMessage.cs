using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingService.Domain
{
    public class GcmMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public long ItemId { get; set; }
    }

    public class GcmNotification
    {
        public List<string> DeviceIds { get; set; }
        public GcmMessage GcmMessage { get; set; }
    }

}

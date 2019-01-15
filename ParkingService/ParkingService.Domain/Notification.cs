using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingService.Domain
{
    //public class Notification
    //{
    //    public string DeviceId { get; set; }
    //    public string Message { get; set; }
    //}

    public class Notification
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }

    public class Payload
    {
        public Notification Notification { get; set; }
        public string To { get; set; }
        public Notification Data { get; set; }
    }
}

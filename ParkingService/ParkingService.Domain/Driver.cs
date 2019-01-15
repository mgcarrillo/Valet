using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingService.Domain
{
    public class Driver
    {
        public int? Id { get; set; }
        public string DriverName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string DeviceId { get; set; }
        public DateTime? Expires { get; set; }
        public bool? Notified { get; set; }
    }
}

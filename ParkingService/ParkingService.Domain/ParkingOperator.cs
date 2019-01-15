using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingService.Domain
{
    public class ParkingOperator
    {
        public string OperatorName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
        public int? NumberOfSpaces { get; set; }
        public decimal? InitialFee { get; set; }
        public int? InitialHours { get; set; }
        public decimal? SubsequentHourlyFee { get; set; }
        public bool? AcceptsCash { get; set; }
        public bool? AcceptsCredit { get; set; }
        public bool? CoveredParking { get; set; }
	    public bool? Open24Hours { get; set; }
        public int? HourOpen { get; set; }
        public int? HourClosed { get; set; }
        public bool? EventParking { get; set; }
        public bool? ParkingGarage { get; set; }
        public double? Distance { get; set; }  // this is distance from point of origin
    }
}

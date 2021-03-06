//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingService.Data
{
    using System;
    
    public partial class sp_GetParkingInRadius_Result
    {
        public string OperatorName { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string StateID { get; set; }
        public string Zip { get; set; }
        public Nullable<int> NumberOfSpaces { get; set; }
        public Nullable<decimal> InitialFee { get; set; }
        public Nullable<int> InitialHours { get; set; }
        public Nullable<decimal> HourlyFee { get; set; }
        public Nullable<bool> AcceptsCash { get; set; }
        public Nullable<bool> AcceptsCredit { get; set; }
        public Nullable<bool> CoveredParking { get; set; }
        public Nullable<bool> Open24Hours { get; set; }
        public Nullable<int> HourOpen { get; set; }
        public Nullable<int> HourClosed { get; set; }
        public bool EventParking { get; set; }
        public bool ParkingGarage { get; set; }
        public Nullable<double> Distance { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
    }
}

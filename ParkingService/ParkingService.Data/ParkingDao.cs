using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingService.Domain;

namespace ParkingService.Data
{
    public interface IParkingDao
    {
        ParkingOperator GetOperatorInfo(int operatorId);
        List<ParkingOperator> GetParkingInRadius(double myLat, double myLong, double radius);

        void InsertParking(string operatorName, double? latitude, double? longitude, string addr1, string city,
            string state, string zip, string phone,
            string website, int? numberOfSpaces, decimal? initFee, int? initHours, decimal? hourlyFee, bool? acceptCash,
            bool? acceptCredit, bool? coveredParking, bool? open24, int? hourOpen, int? hourClosed, bool? eventParking,
            bool? parkingGarage);

        List<ParkingOperator> GetAllOperators();

        void InsertDriver(string driverName, double? latitude, double? longitude, string deviceId, DateTime? expires);
        Driver GetDriverInfo(int driverId);
        List<Driver> GetAllDrivers();
        List<Driver> GetDriversForNotification();
        void NotifyDriver(int driverId);
        void UpdateExpires(string deviceId, DateTime expires);
    }
    public class ParkingDao : IParkingDao
    {
        public ParkingOperator GetOperatorInfo(int operatorId)
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_GetOperatorById(operatorId).FirstOrDefault();
                return (result == null) ? new ParkingOperator() :
                    new ParkingOperator
                    {
                        OperatorName = result.OperatorName,
                        Latitude = result.Latitude,
                        Longitude = result.Longitude,
                        Address1 = result.Address1,
                        City = result.City,
                        State = result.StateID,
                        Zip = result.Zip,
                        Phone = result.Phone,
                        WebsiteUrl = result.WebsiteUrl,
                        NumberOfSpaces = (int)result.NumberOfSpaces,
                        InitialFee = result.InitialFee,
                        InitialHours = result.InitialHours,
                        SubsequentHourlyFee = result.HourlyFee,
                        AcceptsCash = result.AcceptsCash,
                        AcceptsCredit = result.AcceptsCredit,
                        CoveredParking = result.CoveredParking,
                        Open24Hours = result.Open24Hours,
                        HourOpen = result.HourOpen,
                        HourClosed = result.HourClosed,
                        EventParking = result.EventParking,
                        ParkingGarage = result.ParkingGarage,
                    };
            }
        }

        public List<ParkingOperator> GetParkingInRadius(double myLat, double myLong, double radius)
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_GetParkingInRadius(myLat, myLong, radius);
                return (result == null) ? new List<ParkingOperator>() :
                    result.Select(d =>
                       new ParkingOperator
                       {
                           OperatorName = d.OperatorName,
                           Latitude = d.Latitude,
                           Longitude = d.Longitude,
                           Address1 = d.Address1,
                           City = d.City,
                           State = d.StateID,
                           Zip = d.Zip.Trim(),
                           Phone = d.Phone,
                           WebsiteUrl = d.WebsiteUrl,
                           NumberOfSpaces = (int)d.NumberOfSpaces,
                           InitialFee = d.InitialFee,
                           InitialHours = d.InitialHours,
                           SubsequentHourlyFee = d.HourlyFee,
                           AcceptsCash = d.AcceptsCash,
                           AcceptsCredit = d.AcceptsCredit,
                           CoveredParking = d.CoveredParking,
                           Open24Hours = d.Open24Hours,
                           HourOpen = d.HourOpen,
                           HourClosed = d.HourClosed,
                           EventParking = d.EventParking,
                           ParkingGarage = d.ParkingGarage,
                           Distance = Convert.ToDouble(d.Distance),
                       }).ToList();
            }
        }

        public void InsertParking(string operatorName, double? latitude, double? longitude, string addr1, string city,
            string state,
            string zip, string phone, string website, int? numberOfSpaces, decimal? initFee, int? initHours,
            decimal? hourlyFee,
            bool? acceptCash, bool? acceptCredit, bool? coveredParking, bool? open24, int? hourOpen, int? hourClosed,
            bool? eventParking, bool? parkingGarage)
        {
            using (var context = new ValetDBEntities())
            {
                context.sp_Operator_Insert(operatorName, latitude, longitude, addr1, city, state, zip, phone, website,
                    numberOfSpaces, initFee, initHours, hourlyFee, acceptCash, acceptCredit, coveredParking, open24,
                    hourOpen, hourClosed, eventParking, parkingGarage);
            }
        }

        public void InsertDriver(string driverName, double? latitude, double? longitude, string deviceId, DateTime? expires)
        {
            using (var context = new ValetDBEntities())
            {
                context.sp_Driver_Insert(driverName, latitude, longitude,deviceId, expires);
            }
        }

        public void NotifyDriver(int driverId)
        {
            using (var context = new ValetDBEntities())
            {
                context.sp_DriverNotified(driverId);
            }
        }

        public void UpdateExpires(string deviceId, DateTime expires)
        {
            using (var context = new ValetDBEntities())
            {
                context.sp_UpdateExpires(deviceId, expires);
            }
        }


        public Driver GetDriverInfo(int driverId)
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_DriverById(driverId).FirstOrDefault();
                return (result == null) ? new Driver() :
                    new Driver
                    {
                        DriverName = result.DriverName,
                        Latitude = result.Latitude,
                        Longitude = result.Longitude,
                        DeviceId = result.DeviceID,
                        Expires = result.Expires,
                        Notified = result.Notified
                    };
            }
        }

        public List<Driver> GetAllDrivers()
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_GetAllDrivers();
                return (result == null) ? new List<Driver>() :
                    result.Select(d =>
                       new Driver
                       {
                           DriverName = d.DriverName,
                           Latitude = d.Latitude,
                           Longitude = d.Longitude,
                           DeviceId = d.DeviceID,
                           Expires = d.Expires,
                           Notified = d.Notified
                       }).ToList();
            }
        }

        public List<ParkingOperator> GetAllOperators()
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_GetAllOperators();
                return (result == null) ? new List<ParkingOperator>() :
                    result.Select(d =>
                       new ParkingOperator
                       {
                           OperatorName = d.OperatorName,
                           Latitude = d.Latitude,
                           Longitude = d.Longitude,
                           Address1 = d.Address1,
                           City = d.City,
                           State = d.StateID,
                           Zip = d.Zip.Trim(),
                           Phone = d.Phone,
                           WebsiteUrl = d.WebsiteUrl,
                           NumberOfSpaces = (int)d.NumberOfSpaces,
                           InitialFee = d.InitialFee,
                           InitialHours = d.InitialHours,
                           SubsequentHourlyFee = d.HourlyFee,
                           AcceptsCash = d.AcceptsCash,
                           AcceptsCredit = d.AcceptsCredit,
                           CoveredParking = d.CoveredParking,
                           Open24Hours = d.Open24Hours,
                           HourOpen = d.HourOpen,
                           HourClosed = d.HourClosed,
                           EventParking = d.EventParking,
                           ParkingGarage = d.ParkingGarage,
                       }).ToList();
            }
        }

        public List<Driver> GetDriversForNotification()
        {
            using (var context = new ValetDBEntities())
            {
                var result = context.sp_GetDriversToBeNotified();
                return (result == null) ? new List<Driver>() :
                    result.Select(d =>
                       new Driver
                       {
                           Id = d.ID,
                           DriverName = d.DriverName,
                           Latitude = d.Latitude,
                           Longitude = d.Longitude,
                           DeviceId = d.DeviceID,
                           Expires = d.Expires,
                           Notified = d.Notified
                       }).ToList();
            }
        }

    }
}

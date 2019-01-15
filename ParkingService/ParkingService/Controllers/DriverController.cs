using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ParkingService.Data;
using ParkingService.Domain;

namespace ParkingService.Controllers
{
    public class DriverController : ApiController
    {
        private readonly IParkingDao _dao;
        private readonly ISnsClient _snsClient;
        private readonly IGcmClient _gcmClient;
        private const string _cannedMessage = "Parking will expire in 20 minutes";

        public DriverController() : this(ServiceLocator.ParkingDao, ServiceLocator.SnsClient, ServiceLocator.GcmClient)
        {
        }

        public DriverController(IParkingDao dao, ISnsClient sclient, IGcmClient gclient)
        {
            _dao = dao;
            _snsClient = sclient;
            _gcmClient = gclient;
        }

        // GET api/values/5
        [HttpGet]
        public Driver GetDriverById(int driverId)
        {
            return _dao.GetDriverInfo(driverId);
        }

        [HttpGet]
        public List<Driver> GetAllDrivers()
        {
            return _dao.GetAllDrivers();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Driver driver)
        {
            _dao.InsertDriver(driver.DriverName, driver.Latitude, driver.Longitude,
                driver.DeviceId, driver.Expires);
        }

        [HttpPut]
        public void Put([FromBody] UpdatedDriver driver)
        {
            //var hours = driver.Expires.Split(':')[0];
            //var min = driver.Expires.Split(':')[1];
            //var sec = driver.Expires.Split(':')[2];
            //_dao.UpdateExpires(driver.DeviceId, DateTime.Now.Add(new TimeSpan(hours, min, sec)));
            var converted = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            converted = converted.AddSeconds(driver.Expires).ToLocalTime();
            _dao.UpdateExpires(driver.DeviceId, converted);
        }

        ///// <summary>
        /////  pushes a message to driver indicated.  This uses SNS and GCM.
        ///// </summary>
        ///// <param name="driverId"></param>
        ///// <param name="notification"></param>
        //[HttpPut]
        //public void Put(int driverId, [FromBody] Notification notification)
        //{
        //    Driver driver = new Driver();
        //    if (notification.DeviceId == null)
        //    {
        //        driver = _dao.GetDriverInfo(driverId);
        //        notification.DeviceId = driver.DeviceId;
        //        notification.Message = _cannedMessage;
        //    }

        //    notification.Message = notification.Message ?? _cannedMessage;
        //    var endpointArn = _snsClient.CreatePushEndpoint(notification.DeviceId);
        //    _snsClient.SendPush(endpointArn, notification.Message);
        //}

        ///// <summary>
        /////  pushes a message to device Id indicated.  This uses SNS and GCM.
        ///// </summary>
        ///// <param name="deviceId"></param>
        ///// <param name="message"></param>
        //[HttpPut]
        //public void Put(string deviceId, string message)
        //{
        //    message = message ?? _cannedMessage;
        //    var endpointArn = _snsClient.CreatePushEndpoint(deviceId);
        //    _snsClient.SendPush(endpointArn, message);
        //}

        ///// <summary>
        /////  this endpoint sends directly using gcm service, using the specified device id 
        ///// </summary>
        ///// <param name="deviceId"></param>
        ///// <param name="message"></param>
        //[HttpPut]
        //public void Put(string deviceId, [FromBody] GcmMessage message)
        //{
        //    message.Message = message.Message ?? _cannedMessage;
        //    _gcmClient.SendNotification(deviceId, message.Message);
        //}

        ///// <summary>
        ///// this endpoint sends directly using gcm service, using a list of specified device ids 
        ///// </summary>
        ///// <param name="notification"></param>
        //[HttpPut]
        //public void Put([FromBody] GcmNotification notification)
        //{
        //    notification.GcmMessage.Message = notification.GcmMessage.Message ?? _cannedMessage;
        //    _gcmClient.SendNotification(notification.DeviceIds, notification.GcmMessage.Message, notification.GcmMessage.Title, notification.GcmMessage.ItemId);
        //}

    }
}

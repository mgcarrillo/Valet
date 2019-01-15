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
    public class NotifyController : ApiController
    {
        private readonly IParkingDao _dao;
        private readonly ISnsClient _snsClient;
        private readonly IGcmClient _gcmClient;
        private const string _cannedMessage = "Parking will expire in 20 minutes";

        public NotifyController() : this(ServiceLocator.ParkingDao, ServiceLocator.SnsClient, ServiceLocator.GcmClient)
        {
        }

        public NotifyController(IParkingDao dao, ISnsClient sclient, IGcmClient gclient)
        {
            _dao = dao;
            _snsClient = sclient;
            _gcmClient = gclient;
        }
        
        [HttpGet]
        public List<Driver> GetDriversToBeNotified()
        {
            return _dao.GetDriversForNotification();
        }


        /// <summary>
        /// marks driver id was sent notification
        /// </summary>
        /// <param name="driverId"></param>
        [HttpPost]
        public void Post(int driverId)
        {
            _dao.NotifyDriver(driverId);
        }

        /// <summary>
        ///  pushes a message to device Id indicated.  This uses GCM only.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="message"></param>
        [HttpPut]
        public void Put(string deviceId, string message)
        {
            message = message ?? _cannedMessage;

            _gcmClient.SendNotification(deviceId, message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingService.Data;

namespace ParkingService
{
    public static class ServiceLocator
    {
        public static IParkingDao _parkingDao;

        public static IParkingDao ParkingDao
        {
            get { return _parkingDao ?? (_parkingDao = new ParkingDao()); }
            set { _parkingDao = value; }
        }

        public static ISnsClient _snsClient;

        public static ISnsClient SnsClient
        {
            get { return _snsClient ?? (_snsClient = new SnsClient()); }
            set { _snsClient = value; }
        }

        public static IGcmClient _gcmClient;

        public static IGcmClient GcmClient
        {
            get { return _gcmClient ?? (_gcmClient = new GcmClient()); }
            set { _gcmClient = value; }
        }


    }
}
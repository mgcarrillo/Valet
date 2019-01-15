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
    //[Authorize]
    public class ParkingController : ApiController
    {
        private readonly IParkingDao _dao;
        private readonly ISnsClient _snsClient;

        public ParkingController() : this(ServiceLocator.ParkingDao, ServiceLocator.SnsClient)
        { }

        public ParkingController(IParkingDao dao, ISnsClient client)
        {
            _dao = dao;
            _snsClient = client;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ParkingOperator> GetParkingInRadius(double latitude, double longitude, double radius)
        {
            return _dao.GetParkingInRadius(latitude, longitude, radius);
        }

        // GET api/values/5
        [HttpGet]
        public ParkingOperator GetOperatorById(int operatorId)
        {
            return _dao.GetOperatorInfo(operatorId);
        }

        

        [HttpGet]
        public List<ParkingOperator> GetAllOperators()
        {
            return _dao.GetAllOperators();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ParkingOperator parkingOperator)
        {
            _dao.InsertParking(parkingOperator.OperatorName, parkingOperator.Latitude, parkingOperator.Longitude,
                parkingOperator.Address1,
                parkingOperator.City, parkingOperator.State, parkingOperator.Zip, parkingOperator.Phone,
                parkingOperator.WebsiteUrl,
                parkingOperator.NumberOfSpaces, parkingOperator.InitialFee, parkingOperator.InitialHours,
                parkingOperator.SubsequentHourlyFee, parkingOperator.AcceptsCash, parkingOperator.AcceptsCredit,
                parkingOperator.CoveredParking, parkingOperator.Open24Hours,
                parkingOperator.HourOpen, parkingOperator.HourClosed, parkingOperator.EventParking,
                parkingOperator.ParkingGarage);
        }


        // PUT api/values/5
        //[HttpPut]
        //public void Put(int id, [FromBody]string deviceId)
        //{
        //    _client.CreatePlatformEndpointAsync(new CreatePlatformEndpointRequest());

        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}

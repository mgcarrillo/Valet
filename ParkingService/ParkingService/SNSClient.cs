using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace ParkingService
{
    public interface ISnsClient
    {
        string CreatePushEndpoint(string registrationId);
        void SendPush(string endpointArn, string msg);
    }

    public class SnsClient : ISnsClient
    {
        private AmazonSimpleNotificationServiceClient _client;
        public SnsClient()
        {
            _client = new AmazonSimpleNotificationServiceClient();
        }

        public string CreatePushEndpoint(string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId)) throw new Exception("Registration id was null");

            var result = _client.CreatePlatformEndpoint(new CreatePlatformEndpointRequest()
            {
                PlatformApplicationArn = "arn:aws:sns:ap-southeast-2:659169760454:app/GCM/Valet", // TODO consider making this a constant
                Token = registrationId
            });

            return result.EndpointArn;


        }

        public void SendPush(string endpointArn, string msg)
        {
            if (string.IsNullOrEmpty(endpointArn)) throw new Exception("Endpoint ARN was null");

            var pushMsg = new PublishRequest();

            pushMsg.Message = msg;
            pushMsg.TargetArn = endpointArn;

            _client.Publish(pushMsg);
        }
    }
}
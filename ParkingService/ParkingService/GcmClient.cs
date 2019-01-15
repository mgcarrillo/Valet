using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ParkingService.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ParkingService
{
    public interface IGcmClient
    {
        //string SendNotification(string deviceId, string message, string title, long itemId);
        //string SendNotification(List<string> deviceRegIds, string message, string title, long itemId);
        string SendNotification(string deviceId, string message);
    }

    public class GcmClient : IGcmClient
    {

        public string SendNotification(string deviceId, string message)
        {
            var response = string.Empty;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=AAAAI4uB5V0:APA91bF3O2cHOZq_d9EU9emtwNbWKTJjUlo_fBCjXqOoVIF7W2qyVYfjaAAN0g_EeXmKiOLsSaou7XOYXEyZGY7pARte_vTgXJ8OvJunw0y8UuHU1mzFoqqyz0lOOQteVdUdbPNIuu-9");
                var n = new Notification
                {
                    Text = message,
                    Title = "Message from [Valet]"
                };
                var p = new Payload
                {
                    Notification = n,
                    To = deviceId,
                    Data = n 
                    //"f0jqSsdNbb4:APA91bEVeEqSIULPbTAW4qvcAJroDUcJAaD3fGzvIAhPZIdnp7JGmHBbZQY9lklD0hxdOx0V4nh6B2aFbB6WuseMAMZO5UB7syZco-VWEQfgYIWy997rOaAwI_BWU7_SUGMvyrEiYw-6"
                };
                var content = new StringContent(JsonConvert.SerializeObject(p, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }), Encoding.UTF8, "application/json");
                var r = client.PostAsync("https://gcm-http.googleapis.com/gcm/send", content).Result;
                if (!r.IsSuccessStatusCode)
                {
                    response = r.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    response = "Success!";
                }
            }
            return response;
        }
    }
}

//    public string SendNotification(string deviceId, string message, string title, long itemId)
        //    {
        //        return SendNotification(new List<string> { deviceId }, message, title, itemId);
        //    }

        //    public string SendNotification(List<string> deviceRegIds, string message, string title, long itemId)
        //    {

        //        string SERVER_API_KEY = "AAAAI4uB5V0:APA91bF3O2cHOZq_d9EU9emtwNbWKTJjUlo_fBCjXqOoVIF7W2qyVYfjaAAN0g_EeXmKiOLsSaou7XOYXEyZGY7pARte_vTgXJ8OvJunw0y8UuHU1mzFoqqyz0lOOQteVdUdbPNIuu-9";
        //        var SENDER_ID = "152664401245";
        //        string regIds = string.Join("\",\"", deviceRegIds);

        //        GcmMessage msg = new GcmMessage();
        //        msg.Title = title;
        //        msg.Message = message;
        //        msg.ItemId = itemId;

        //        var value = Newtonsoft.Json.JsonConvert.SerializeObject(msg);

        //        WebRequest tRequest;
        //        tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
        //        tRequest.Method = "post";
        //        tRequest.ContentType = "application/json";
        //        tRequest.Headers.Add($"Authorization: key={SERVER_API_KEY}");

        //        tRequest.Headers.Add($"Sender: id={SENDER_ID}");

        //        string postData = "{\"collapse_key\":\"score_update\",\"time_to_live\":108,\"delay_while_idle\":true,\"data\": { \"message\" : " + value + ",\"time\": " + "\"" + DateTime.Now.ToString() + "\"},\"registration_ids\":[\"" + regIds + "\"]}";

        //        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //        tRequest.ContentLength = byteArray.Length;

        //        Stream dataStream = tRequest.GetRequestStream();
        //        dataStream.Write(byteArray, 0, byteArray.Length);
        //        dataStream.Close();

        //        WebResponse tResponse = tRequest.GetResponse();

        //        dataStream = tResponse.GetResponseStream();

        //        StreamReader tReader = new StreamReader(dataStream);

        //        String sResponseFromServer = tReader.ReadToEnd();

        //        tReader.Close();
        //        dataStream.Close();
        //        tResponse.Close();
        //        return sResponseFromServer;
        //    }
        //}

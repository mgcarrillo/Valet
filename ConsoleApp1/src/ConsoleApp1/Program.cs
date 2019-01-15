using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.UtcNow);

            while (true)
            {
                var drivers = new List<Driver>();
                var url = "http://parkingservice.us-east-1.elasticbeanstalk.com";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = client.GetAsync("api/Notify").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        drivers = JsonConvert.DeserializeObject<List<Driver>>(jsonString);
                    }
                }

                foreach (var driver in drivers)
                {
                    if (!string.IsNullOrEmpty(driver.DeviceId))
                    {
                        var response = string.Empty;
                        var puturl = "http://parkingservice.us-east-1.elasticbeanstalk.com/api/Notify";
                        var posturl = "https://gcm-http.googleapis.com/gcm/send";
                        using (var client = new HttpClient())
                        {
                            //"http://parkingservice.us-east-1.elasticbeanstalk.com/api/Notify?deviceId=f0jqSsdNbb4:APA91bEVeEqSIULPbTAW4qvcAJroDUcJAaD3fGzvIAhPZIdnp7JGmHBbZQY9lklD0hxdOx0V4nh6B2aFbB6WuseMAMZO5UB7syZco-VWEQfgYIWy997rOaAwI_BWU7_SUGMvyrEiYw-6&message=test"

                            var x = DateTime.UtcNow.Subtract(driver.Expires ?? DateTime.UtcNow.AddMinutes(10)).TotalMinutes;
                            var expireMessage = (x <= 0) ?
                                $"Your parking will expire in {Math.Abs(Convert.ToInt32(x))} minutes." :
                                $"Your parking expired {Math.Abs(Convert.ToInt32(x))} minutes ago.";

                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=AAAAI4uB5V0:APA91bF3O2cHOZq_d9EU9emtwNbWKTJjUlo_fBCjXqOoVIF7W2qyVYfjaAAN0g_EeXmKiOLsSaou7XOYXEyZGY7pARte_vTgXJ8OvJunw0y8UuHU1mzFoqqyz0lOOQteVdUdbPNIuu-9");
                            var n = new Notification
                            {
                                Text = expireMessage,
                                Title = "Message from [Valet]"
                            };
                            var p = new Payload
                            {
                                Notification = n,
                                To = driver.DeviceId,
                                Data = n
                                //"f0jqSsdNbb4:APA91bEVeEqSIULPbTAW4qvcAJroDUcJAaD3fGzvIAhPZIdnp7JGmHBbZQY9lklD0hxdOx0V4nh6B2aFbB6WuseMAMZO5UB7syZco-VWEQfgYIWy997rOaAwI_BWU7_SUGMvyrEiYw-6"
                            };
                            var content = new StringContent(JsonConvert.SerializeObject(p, new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json");

                            //var r = client.PutAsync(
                            //    $"{puturl}?deviceId={driver.DeviceId}&message={expireMessage}", null).Result;

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

                        if (response.Equals("Success!", StringComparison.CurrentCultureIgnoreCase))
                        {
                            using (var client = new HttpClient())
                            {
                                var r = client.PostAsync(
                                    $"{puturl}?driverId={driver.Id}", null).Result;
                            }

                        }
                    }
                }
                //Thread.Sleep(30000);
            }
        }


    }

    public class Notification
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }

    public class Payload
    {
        public Notification Notification { get; set; }
        public string To { get; set; }
        public Notification Data { get; set; }
    }
}

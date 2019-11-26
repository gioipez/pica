using Microsoft.Extensions.Configuration;
using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
{
    public class WebServiceHilton : WebServiceFactory
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public override async Task<bool> Cancel(reserve reserve)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceHilton = configuration.GetValue<string>("WebServiceHilton");
            webServiceHilton += "cancelRoom";

            room room = new room
            {
                order_id = reserve.order_id.ToString()
            };

            string body = JsonConvert.SerializeObject(room);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceHilton, stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception(await httpResponseMessage.Content.ReadAsStringAsync());
            }
        }

        public override async Task<bool> Reserve(reserve reserve)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceHilton = configuration.GetValue<string>("WebServiceHilton");
            webServiceHilton += "reserveRoom";

            room room = new room
            {
                order_id = reserve.order_id.ToString(),
                hotel_id = reserve.hotel_id,
                room_number = reserve.room_number,
                check_in_date = reserve.check_in_date,
                check_out_date = reserve.check_out_date,
                state = reserve.state,
                guest_name = reserve.guest_name
            };

            string body = JsonConvert.SerializeObject(room);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceHilton, stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception(await httpResponseMessage.Content.ReadAsStringAsync());
            }
        }
    }
}
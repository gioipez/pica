using Microsoft.Extensions.Configuration;
using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Providers
{
    public class WebServiceAvianca : WebServiceFactory
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public override async Task<bool> Cancel(reserve reserve)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceAvianca = configuration.GetValue<string>("WebServiceAvianca");
            webServiceAvianca += "cancelFlight";

            flight flight = new flight
            {
                order_id = reserve.order_id
            };

            string body = JsonConvert.SerializeObject(flight);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceAvianca, stringContent);

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

            string webServiceAvianca = configuration.GetValue<string>("WebServiceAvianca");
            webServiceAvianca += "reserveFlight";

            flight flight = new flight
            {
                order_id = reserve.order_id,
                first_name = reserve.first_name,
                last_name = reserve.last_name,
                departure_date = reserve.departure_date,
                departure_hour = reserve.departure_hour,
                trip_number = reserve.trip_number,
                chair_number = reserve.chair_number,
                origin = reserve.origin,
                destiny = reserve.destiny
            };

            string body = JsonConvert.SerializeObject(flight);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceAvianca, stringContent);

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
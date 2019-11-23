using Microsoft.Extensions.Configuration;
using MoteeQueso.Providers.Lodging.Core.Factories;
using MoteeQueso.Providers.Lodging.Infraestructure.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoteeQueso.Providers.Lodging.Core.Providers
{
    public class WebServiceHilton : WebServiceFactory
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public override async Task<Guid> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override async Task<Guid> Reserve(reserve reserve)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceHilton = configuration.GetValue<string>("WebServiceHilton");
            webServiceHilton += "reserveRoom";

            room room = new room
            {
                id = reserve.id,
                agreement_id = reserve.agreement_id,
                days = reserve.days
            };

            string body = JsonConvert.SerializeObject(room);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceHilton, stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                room = JsonConvert.DeserializeObject<room>(response);
                
                return room.filed;
            }
            else
            {
                throw new Exception(await httpResponseMessage.Content.ReadAsStringAsync());
            }
        }
    }
}
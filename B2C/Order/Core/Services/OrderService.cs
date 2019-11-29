using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoteeQueso.B2C.Order.Core.Interfaces;
using MoteeQueso.B2C.Order.Infraestructure.Data;
using MoteeQueso.B2C.Order.Infraestructure.Entities;
using MoteeQueso.B2C.Order.Infraestructure.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MoteeQueso.B2C.Order.Core.Services
{
    public class OrderService : IOrderService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<int> CreateOrder(order order)
        {
            order.status_id = 1;

            using (TransactionScope transaction = new TransactionScope(
                TransactionScopeOption.Required, 
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                using (B2COrderEntities entities = new B2COrderEntities())
                {
                    entities.order.Add(order);
                    await entities.SaveChangesAsync();
                }

                transaction.Complete();
            }

            foreach (item item in order.items)
            {
                switch ((product_type)item.product_type_id)
                {
                    case product_type.Lodging:
                        await CreateReserveLodging(item);
                        break;
                    case product_type.Transport:
                        await CreateReserveTransport(item);
                        break;
                    case product_type.Show:
                        break;
                    default:
                        throw new NotImplementedException("Not Implemented Integration For Product Type Id: " + item.product_type_id);
                }
            }

            return order.id;
        }

        public async Task CreateReserveLodging(item item)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceLodging = configuration.GetValue<string>("WebServiceLodging");

            reserve_lodging reserve_Lodging = new reserve_lodging
            {
                provider_id = item.product_id,
                integration_type_id = item.product_integration_type_id,
                order_id = item.order.id,
                hotel_id = 1,
                room_number = 1,
                check_in_date = DateTime.Now,
                check_out_date = DateTime.Now,
                state = item.order.status_id,
                guest_name = ""
            };

            string body = JsonConvert.SerializeObject(reserve_Lodging);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceLodging, stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await UpdateOrderStatus(item.order.id, 2);
            }
            else
            {
                await UpdateOrderStatus(item.order.id, 3);
            }
        }

        public async Task CreateReserveTransport(item item)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string webServiceTransport = configuration.GetValue<string>("WebServiceTransport");

            reserve_transport reserve_Transport = new reserve_transport
            {
                provider_id = item.product_id,
                integration_type_id = item.product_integration_type_id,
                order_id = item.order.id,
                first_name = "",
                last_name = "",
                departure_date = DateTime.Now,
                departure_hour = 8,
                trip_number = 2,
                chair_number = 14,
                origin = "",
                destiny = ""
            };

            string body = JsonConvert.SerializeObject(reserve_Transport);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceTransport, stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await UpdateOrderStatus(item.order.id, 2);
            }
            else
            {
                await UpdateOrderStatus(item.order.id, 3);
            }
        }

        public async Task UpdateOrderStatus(int id, int status_id)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                order order = await entities.order.FirstOrDefaultAsync(x => x.id == id);
                order.status_id = status_id;

                entities.Entry(order).State = EntityState.Modified;
                await entities.SaveChangesAsync();
            }
        }

        public async Task<order> GetOrder(int id)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                return await entities.order.Include(x => x.status)
                    .Include(x => x.items).FirstOrDefaultAsync(x => x.id == id);
            }
        }

        public async Task<List<order>> GetOrders(int customer_id, int page, int count)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                return await entities.order.Include(x => x.status)
                    .Where(x => x.customer_id == customer_id).ToListAsync();
            }
        }
    }
}
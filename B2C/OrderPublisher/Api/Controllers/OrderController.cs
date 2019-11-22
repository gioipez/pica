using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MoteeQueso.B2C.Order.Api.ViewModels;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MoteeQueso.B2C.Order.Api.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder(OrderDetailViewModel orderDetailViewModel)
        {
            return Ok(Publish(orderDetailViewModel, "CreateOrder"));
        }

        private bool Publish(OrderDetailViewModel orderDetailViewModel, string queue)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = configuration.GetValue<string>("RabbitMQ"),
                UserName = "admin",
                Password = "admin",
                Port = 5672
            };

            using (IConnection connection = connectionFactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(orderDetailViewModel));

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);

                    return true;
                }
            }
        }
    }
}
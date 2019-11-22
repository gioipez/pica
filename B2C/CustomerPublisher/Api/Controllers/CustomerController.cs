using System;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MoteeQueso.B2C.CustomerPublisher.Api.ViewModels;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MoteeQueso.B2C.CustomerPublisher.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCustomer(CustomerViewModel customerViewModel)
        {
            return Ok(Publish(customerViewModel, "CreateCustomer"));
        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerViewModel customerViewModel)
        {
            return Ok(Publish(customerViewModel, "UpdateCustomer"));
        }

        private bool Publish(CustomerViewModel customerViewModel, string queue)
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
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(customerViewModel));

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
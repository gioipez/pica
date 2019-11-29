using System;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReciveOrders.Modelos;
using RestSharp;

namespace ReciveOrders
{

    class Program
    {
        public const string cola = "CreateOrder";
        public const string urlCreateOrder = "http://52.170.232.119:8082/api/order";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "52.170.80.117", Port = 5672 };
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.VirtualHost = "/";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: cola,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] " + cola + "=> Received {0}", message);

                    OrderDetailViewModel order = JsonConvert.DeserializeObject<OrderDetailViewModel>(message);

                    ClienteRestSharp cliente = new ClienteRestSharp();
                    IRestResponse responseOrder = cliente.Request(urlCreateOrder, Method.POST, order);
                    //IRestResponse responseAuth = cliente.Request(urlCreateUsrAuth, Method.POST, userAuth);

                    if (responseOrder.StatusCode == HttpStatusCode.OK)
                    {
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        Console.WriteLine("Ok Response Order -> {0}", responseOrder.Content);
                    }
                    else
                    {
                        Console.WriteLine("Fail");
                        Console.WriteLine(" Response StatusCode -> {0} Response -> {1}", responseOrder.StatusCode, responseOrder.Content);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                        IBasicProperties propiedadesCola = channel.CreateBasicProperties();
                        propiedadesCola.Persistent = true;
                        //channel.BasicReject(deliveryTag: ea.DeliveryTag, requeue: true);
                        channel.BasicPublish(string.Empty, cola, propiedadesCola, Encoding.UTF8.GetBytes(message));
                    }
                    Thread.Sleep(10000);
                };
                channel.BasicConsume(queue: cola, autoAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

    }
}

using System;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ReciveClients {

    class Program {
        public const string cola = "QueueClients";
        static void Main (string[] args) {
            var factory = new ConnectionFactory () { HostName = "52.170.80.117", Port = 5672 };
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.VirtualHost = "/";
            using (var connection = factory.CreateConnection ())
            using (var channel = connection.CreateModel ()) {
                channel.QueueDeclare (queue: cola,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                channel.BasicQos (prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine (" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer (channel);

                consumer.Received += (model, ea) => {
                    
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString (body);

                    //Console.WriteLine (message);

                    //NotificacionConteo msn = JsonConvert.DeserializeObject<NotificacionConteo> (message.ToString ());
                    Console.WriteLine (" [x] " + cola + "=> Received {0}", message);
                    //Console.WriteLine (" [x] " + cola + "=> Received {0}", msn.tipoConteo);
                    Thread.Sleep(5000);

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                    IBasicProperties propiedadesCola = channel.CreateBasicProperties();
                    propiedadesCola.Persistent = true;
                    //channel.BasicReject(deliveryTag: ea.DeliveryTag, requeue: true);
                    channel.BasicPublish(string.Empty, cola, propiedadesCola, Encoding.UTF8.GetBytes(message));
                };
                channel.BasicConsume (queue: cola, autoAck: false, consumer: consumer);

                Console.WriteLine (" Press [enter] to exit.");
                Console.ReadLine ();
            }
        }
    }
}
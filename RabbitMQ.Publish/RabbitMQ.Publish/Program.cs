using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            //Funciona........................................................................................
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();

            //Funciona........................................................................................
            //ConnectionFactory connFactory = new ConnectionFactory();
            //connFactory.Uri = new Uri("amqp://localhost");

            //    using (var conn = connFactory.CreateConnection())
            //    using (var channel = conn.CreateModel())
            //    {
            //        // The message we want to put on the queue
            //        var message = DateTime.Now.ToString("F");
            //        // the data put on the queue must be a byte array
            //        var data = Encoding.UTF8.GetBytes(message);
            //        // ensure that the queue exists before we publish to it
            //        var queueName = "queue1";
            //        bool durable = true;
            //        bool exclusive = false;
            //        bool autoDelete = false;
            //        channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
            //        // publish to the "default exchange", with the queue name as the routing key
            //        var exchangeName = "";
            //        var routingKey = "queue1";
            //        channel.BasicPublish(exchangeName, routingKey, null, data);
            //    }
            //    // return new EmptyResult();
        }
    }
}

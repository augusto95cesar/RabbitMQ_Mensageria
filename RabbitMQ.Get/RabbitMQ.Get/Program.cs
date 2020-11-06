using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Get
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory connFactory = new ConnectionFactory();
            connFactory.Uri = new Uri("amqp://localhost");
            using (var conn = connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                // channel.QueueDeclare("queue1", false, false, false, null);
                // var queueName = "queue1"; 
                var queueName = "hello";
                var data = channel.BasicGet(queueName, false);
                if (data == null)
                    Console.WriteLine(".............................................");
                else
                {
                   //onsole.WriteLine(data.Body);

                    var body = data.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    channel.BasicAck(data.DeliveryTag, false);

                  //Console.WriteLine(".............................................");
                    Console.WriteLine(message);
                }
               //onsole.WriteLine("...................FIM SYSTEM.......................");
                Console.ReadLine();
            }
        }
    }
}

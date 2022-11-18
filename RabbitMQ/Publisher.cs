using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();

            //Create RabbitMQ Connection
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                //Create a channel
                using (var channel = connection.CreateModel())
                {
                    //Declare a queue
                    channel.QueueDeclare(queueName, false, false, false, null);

                    //Publish message
                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));

                    //Log to see the output
                    Console.WriteLine($"Message : {message} --> written on queue : {queueName}");
                }
            }
        }

    }
}

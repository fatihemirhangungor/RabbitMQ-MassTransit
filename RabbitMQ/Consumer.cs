using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMQService();

            //Create RabbitMQ Connection
            using var connection = _rabbitMQService.GetRabbitMQConnection();

            //Create a channel
            using var channel = connection.CreateModel();

            //Create a consumer
            var consumer = new EventingBasicConsumer(channel);

            //Received event remains in listening mode
            consumer.Received += (model, EventArgs) =>
            {
                var body = EventArgs.Body;
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message : {message} read from {queueName} queue");
            };

            //Consume
            channel.BasicConsume(queueName, true, consumer);

            Console.ReadLine();
        }
    }
}

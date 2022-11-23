using System;
using System.Threading;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.RabbitMQ;

namespace RabbitMQ
{
    public class Program
    {
        private static readonly string _queueName = "FATIHGUNGOR";
        private static Publisher _publisher;
        private static Consumer _consumer;

        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Durable = true;
                    var url = "localhost";
                    cfg.Host(new Uri(url), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                }));
            });
            //Create a publisher and send a message
            _publisher = new Publisher(_queueName, "Hello RabbitMQ World!");

            //Sleep for 3 seconds for better console logging
            Thread.Sleep(3000);

            //Create a consumer and listen from queue
            _consumer = new Consumer(_queueName);

            Console.ReadKey();
        }
    }
}

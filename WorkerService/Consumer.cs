using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WorkerService
{
    public class Consumer : IConsumer<HelloMessage>
    {
        //public readonly ILogger logger;
        //public MessageConsumer(ILogger<HelloMessage> logger)
        //{
        //    this.logger = logger;
        //}

        public Task Consume(ConsumeContext<HelloMessage> context)
        {
            //logger.LogInformation("Hello {Name}", context.Message.Name);
            Console.WriteLine($"Hello {JsonConvert.SerializeObject(context.Message.Name)}");

            return Task.CompletedTask;
        }
    }
}

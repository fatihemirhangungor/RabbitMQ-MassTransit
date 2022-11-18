using System;
using System.Threading;

namespace RabbitMQ
{
    public class Program
    {
        private static readonly string _queueName = "FATIHGUNGOR";
        private static Publisher _publisher;
        private static Consumer _consumer;

        static void Main(string[] args)
        {
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

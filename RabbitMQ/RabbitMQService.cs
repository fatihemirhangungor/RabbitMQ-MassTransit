using RabbitMQ.Client;

namespace RabbitMQ
{
    public class RabbitMQService
    {
        private readonly string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                /*
                 
                  Define the host
                 
                  If we wanted to take precaution, it is enough to set up a username and password

                 */ 

                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}

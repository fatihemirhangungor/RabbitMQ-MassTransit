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
        
                 * RabbitMQ'nun bağlantı kuracağı host'u tanımlıyoruz.
                 
                 * Herhangi bir güvenlik önlemi koymak istersek
                   Management ekranından password adımlarını tanımlayıp factory içerisindeki
                   "UserName" ve "Password" property'lerini set etmemiz yeterlidir.

                 */ 

                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}

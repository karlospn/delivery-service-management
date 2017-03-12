using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using delivery.management.message.contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace delivery.management.webui.RabbitMqManager
{
    public class RabbitMqManager : IRabbitMqManager
    {

        public void SendOrder(IOrderForRegistration model)
        {
            var factory = new ConnectionFactory() { Uri = RabbitMqConstants.RabbitMqUri };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare( 
                    exchange: RabbitMqConstants.RegisterOrderExchange,
                    type: ExchangeType.Direct);

                channel.QueueDeclare(
                    queue: RabbitMqConstants.RegisterOrderQueue, 
                    durable: false,
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);

                channel.QueueBind(
                    queue: RabbitMqConstants.RegisterOrderQueue,
                    exchange: RabbitMqConstants.RegisterOrderExchange,
                    routingKey: "");

                var serializedModel = JsonConvert.SerializeObject(model);


                var messageProperties = channel.CreateBasicProperties();
                messageProperties.ContentType =
                    RabbitMqConstants.JsonMimeType;

                channel.BasicPublish(
                    exchange: RabbitMqConstants.RegisterOrderExchange,
                    routingKey: "",
                    basicProperties: messageProperties,
                    body: Encoding.UTF8.GetBytes(serializedModel));
            }
        }

    }
}

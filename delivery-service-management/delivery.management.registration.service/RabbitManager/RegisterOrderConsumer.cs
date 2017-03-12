using System;
using System.Text;
using delivery.management.message.contracts;
using delivery.management.registration.service.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace delivery.management.registration.service.RabbitManager
{
    public class RegisterOrderConsumer : DefaultBasicConsumer
    {
        private readonly IRabbitMqManager rabbitMqManager;

        public RegisterOrderConsumer(
            IRabbitMqManager rabbitMqManager)
        {
            this.rabbitMqManager = rabbitMqManager;
        }

        public override void HandleBasicDeliver(
            string consumerTag, ulong deliveryTag,
            bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, byte[] body)
        {
            if (properties.ContentType != RabbitMqConstants.JsonMimeType)
                throw new ArgumentException(
                    $"Can't handle content type {properties.ContentType}");

            var message = Encoding.UTF8.GetString(body);
            var commandObj =
                JsonConvert.DeserializeObject<RegisterOrderModel>(
                    message);
           // ConsumeLogicBusiness(commandObj);
            rabbitMqManager.SendAck(deliveryTag);
        }

    }
}

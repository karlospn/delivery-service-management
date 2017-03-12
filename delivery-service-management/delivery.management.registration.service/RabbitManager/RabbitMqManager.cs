using System.Text;
using delivery.management.message.contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace delivery.management.registration.service.RabbitManager
{
    public class RabbitMqManager: IRabbitMqManager
    {
        private readonly IModel channel;

        public RabbitMqManager()
        {
            var connectionFactory = new ConnectionFactory { Uri = RabbitMqConstants.RabbitMqUri };
            var connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            connection.AutoClose = true;
        }

        public void ConsumeForRegisterNotifications()
        {
            channel.QueueDeclare(
               queue: RabbitMqConstants.RegisterOrderQueue,
               durable: false, exclusive: false,
               autoDelete: false, arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1,
                global: false);

            var consumer = new RegisterOrderConsumer(this);

            channel.BasicConsume(
                queue: RabbitMqConstants.RegisterOrderQueue,
                consumer: consumer);
        }

        public void PublishRegisteredNotification(IOrderRegistered order)
        {
            channel.ExchangeDeclare(
            exchange: RabbitMqConstants.OrderRegisteredExchange,
            type: ExchangeType.Fanout);

            channel.QueueDeclare(
                queue: RabbitMqConstants.OrderRegisteredNotificationQueue,
                durable: false, exclusive: false,
                autoDelete: false, arguments: null);

            channel.QueueBind(
                queue: RabbitMqConstants.OrderRegisteredNotificationQueue,
                exchange: RabbitMqConstants.OrderRegisteredExchange,
                routingKey: "");

            var serializedOrder = JsonConvert.SerializeObject(order);

            var messageProperties = channel.CreateBasicProperties();
            messageProperties.ContentType = RabbitMqConstants.JsonMimeType;

            channel.BasicPublish(
                exchange: RabbitMqConstants.OrderRegisteredExchange,
                routingKey: "",
                basicProperties: messageProperties,
                body: Encoding.UTF8.GetBytes(serializedOrder));
        }

        public void SendAck(ulong deliveryTag)
        {
            channel.BasicAck(deliveryTag: deliveryTag, multiple: false);
        }
    }
}

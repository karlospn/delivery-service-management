using delivery.management.message.contracts;

namespace delivery.management.registration.service.RabbitManager
{
    public interface IRabbitMqManager
    {
        void ConsumeForRegisterNotifications();
        void PublishRegisteredNotification(IOrderRegistered order);
        void SendAck(ulong deliveryTag);
    }
}
using delivery.management.message.contracts;

namespace delivery.management.webui.RabbitMqManager
{
    public interface IRabbitMqManager
    {
        void SendOrder(IOrderForRegistration order);
    }
}
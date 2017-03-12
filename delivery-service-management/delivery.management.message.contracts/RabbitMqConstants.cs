using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace delivery.management.message.contracts
{
    public static class RabbitMqConstants
    {
        public const string RabbitMqUri =
           "amqp://guest:guest@localhost:5672/";
        public const string JsonMimeType =
            "application/json";

        public const string RegisterOrderExchange =
            "delivery.management.registerorder.exchange";
        public const string RegisterOrderQueue =
            "delivery.management.registerorder.queue";

        public const string OrderRegisteredExchange =
            "delivery.management.orderregistered.exchange";
        public const string OrderRegisteredNotificationQueue =
            "delivery.management.orderregistered.notification.queue";
    }
}

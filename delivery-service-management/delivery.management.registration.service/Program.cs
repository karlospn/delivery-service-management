using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delivery.management.registration.service.RabbitManager;
using Microsoft.Extensions.DependencyInjection;

namespace delivery.management.registration.service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           .AddTransient<IRabbitMqManager, RabbitMqManager>()
           .BuildServiceProvider();

            var service = serviceProvider.GetService<IRabbitMqManager>(); 
            service.ConsumeForRegisterNotifications();
            Console.WriteLine("Listening for RegisterOrderCommand..");
            Console.ReadKey();

        }
    }
}

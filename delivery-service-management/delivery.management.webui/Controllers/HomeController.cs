using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delivery.management.webui.Models;
using delivery.management.webui.RabbitMqManager;
using delivery.management.webui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace delivery.management.webui.Controllers
{
    public class HomeController : Controller
    {
        public IRabbitMqManager RabbitMqManager { get; }

        public HomeController(IRabbitMqManager rabbitMqManager)
        {
            RabbitMqManager = rabbitMqManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterOrder(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = AutoMapper.Mapper.Map<RegisterOrderModel>(viewModel);
                RabbitMqManager.SendOrder(model);
                return View("Thanks");
            }
            ModelState.AddModelError("", "There are some required fields left empty");
            return View("Index");
        }
    }
}

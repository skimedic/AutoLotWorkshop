using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Web.ConfigSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoLot.Web.Models;
using Microsoft.Extensions.Options;

namespace AutoLot.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices]IOptionsMonitor<DealerInfo> dealerMonitor)
        {
            var vm = dealerMonitor.CurrentValue;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [HttpGet]
        public IActionResult RazorSyntax([FromServices] ICarRepo carRepo)
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

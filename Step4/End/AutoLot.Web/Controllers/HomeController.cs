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
    [Route("[controller]/[action]")]
    //[Route("Home/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        [HttpGet]
        public IActionResult Index([FromServices] IOptionsMonitor<DealerInfo> dealerMonitor)
        {
            var vm = dealerMonitor.CurrentValue;
            return View(vm);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RazorSyntax([FromServices] ICarRepo repo)
        {
            var vm = repo.Find(1);
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - HomeController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/08
// See License.txt for more information
// ==================================

using System.Diagnostics;
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

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
        public IActionResult RazorSyntax([FromServices] ICarRepo carRepo)
        {
            var car = carRepo.Find(1);
            return View(car);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Part3_Mod35.Models;
using Part3_Mod35.Data.UoW;
using AutoMapper;
using Part3_Mod35.ViewModels.Account;

namespace Part3_Mod35.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View(new MainViewModel());
        }

        [Route("[action]")]
        public IActionResult Privacy()
        {
            ViewData["Iframe"] = @"<iframe name='myIframe' id='myIframe' width='100%' height='300' src='Chat?id=401b8c06-2730-406c-8edd-441aa94f121d'></iframe>";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

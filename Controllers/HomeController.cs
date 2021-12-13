using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View(new SiteBackEnd.Views.Home.Index());
            }
            catch(Exceptions.SQL e)
            {
                Response.StatusCode = 500;
                return View("../Error/Server") ;
            }
        }

    }
}

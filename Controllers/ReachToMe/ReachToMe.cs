using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers.ReachToMe
{
    [Route("/reachtome")]
    public class ReachToMe : Controller
    {
        [Route("")]
        public IActionResult Index() {
            return View("../Home/ReachToMe/Index");
        }
    }
}

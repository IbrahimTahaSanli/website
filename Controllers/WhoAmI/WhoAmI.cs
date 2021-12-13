using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers.WhoAmI
{
    [Route("whoami")]
    public class WhoAmI : Controller
    {
        [Route("")]
        public IActionResult Get()
        {
            return View("../Home/WhoAmI/Index");
        }
    }
}

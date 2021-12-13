using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers.Opinions
{
    [Route("opinions/")]
    public class OpinionsController : Controller
    {
        public IActionResult Index()
        {
            return View("../Home/Opinions/Index", new Views.Home.Opinions.Index(0));
        }

        [Route("{i}")]
        public IActionResult Index(int i)
        {
            try
            {
                return View("../Home/Opinions/Index", new Views.Home.Opinions.Index(i));
            }
            catch(Exceptions.OutOfIndex e)
            {
                Response.StatusCode = 404;
                
                return View("../Error/NotFound");
            }
        }

        [Route("option/{str}")]
        public IActionResult ToPage(string str)
        {
            Models.Home.QueryModel.PathModel path = Articles.ArticlesSql.GetPath(str);


            if (!System.IO.File.Exists("Views/Home/Options/Option/" + path.Path + ".cshtml"))
            {
                Response.StatusCode = 404;
                return View("../Error/NotFound");
            }
            return View("../Home/Options/Option/" + path.Path);

        }
    }
}

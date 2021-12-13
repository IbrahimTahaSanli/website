using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SiteBackEnd.Controllers.Articles
{
    [Route("articles/")]
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View("../Home/Articles/Index", new Views.Home.Articles.Index(0));
        }

        [Route("{i}")]
        public IActionResult Index(int i)
        {
            try
            {
                return View("../Home/Articles/Index", new Views.Home.Articles.Index(i));
            }
            catch(Exceptions.OutOfIndex e)
            {
                Response.StatusCode = 404;

                return View("../Error/NotFound");
            }
         }

        [Route("article/{str}")]
        public IActionResult ToPage(string str)
        {
            Models.Home.QueryModel.PathModel path = Articles.ArticlesSql.GetPath(str);
            if (!System.IO.File.Exists("Views/Home/Articles/Article/" + path.Path + ".cshtml"))
            {
                Response.StatusCode = 404;
                return View("../Error/NotFound");
            }
            return View("../Home/Articles/Article/" + path.Path);
        }
    }
}

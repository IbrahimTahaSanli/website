using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Views.Home
{
    public class Index : PageModel
    {
        public Models.Home.HomeBoard[] OpinionList;
        public Models.Home.HomeBoard[] ArticleList;

        public Index() {
            OpinionList = SiteBackEnd.Controllers.SQL.getOpiDatas();
            ArticleList = SiteBackEnd.Controllers.SQL.getArtDatas();
        }


        public void OnGet() { }
        
    }
}

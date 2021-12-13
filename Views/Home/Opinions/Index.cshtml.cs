using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Views.Home.Opinions
{
    public class Index : PageModel
    {
        public Models.Home.HomeBoard[] boards;
        public int Count;
        public int AllPageNumber;
        public int CurrentPageNumber;

        public Index(int i)
        {
            Count = Controllers.Opinions.OpinionsSql.GetCount();
            AllPageNumber = (int)Math.Ceiling( Count/5.0f);
            if (i > AllPageNumber)
                throw new Controllers.Exceptions.OutOfIndex();

            if(Count != 0)
                boards = SiteBackEnd.Controllers.Opinions.OpinionsSql.GetBoard(i);
            CurrentPageNumber = i;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers.Exceptions
{
    [Serializable]
    public class SQL : Exception
    {
        public SQL()
        { }

        public SQL(string message)
            : base(message)
        { }

        public SQL(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

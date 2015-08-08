using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class AdminCommandNotFoundException : Exception
    {
        public AdminCommandNotFoundException()
        {

        }

        public AdminCommandNotFoundException(string message)
            : base(message)
        {
        }

        public AdminCommandNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

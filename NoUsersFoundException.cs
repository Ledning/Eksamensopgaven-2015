using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class NoUsersFoundException : Exception
    {
        public NoUsersFoundException()
        {

        }

        public NoUsersFoundException(string message)
            : base(message)
        {
        }

        public NoUsersFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

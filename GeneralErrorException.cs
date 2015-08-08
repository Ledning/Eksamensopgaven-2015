using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class GeneralErrorException : Exception
    {
        public GeneralErrorException()
        {

        }

        public GeneralErrorException(string message)
            : base(message)
        {
        }

        public GeneralErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

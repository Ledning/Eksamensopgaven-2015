using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class NoProductsFoundException : Exception  //Dette er fundet på MSDN
    {
        public NoProductsFoundException()
        {

        }

        public NoProductsFoundException(string message)
            : base(message)
        {
        }

        public NoProductsFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

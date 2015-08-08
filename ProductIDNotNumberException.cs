using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class ProductIDNotNumberException : Exception
    {
        public ProductIDNotNumberException()
        {

        }

        public ProductIDNotNumberException(string message)
            : base(message)
        {
        }

        public ProductIDNotNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

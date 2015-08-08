using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class IllegalCashTransactionException : Exception
    {
        public IllegalCashTransactionException()
        {

        }

        public IllegalCashTransactionException(string message)
            : base(message)
        {
        }

        public IllegalCashTransactionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

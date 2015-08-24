using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction (User currentUser, decimal amount)
        {
            _transactionID = ++_transactionIDCounter;
            _currentUser = currentUser;
            _date = DateTime.Now;
            _amount = amount;
        }

        public override string ToString()
        {
            return "Indsat Beløb " + _amount.ToString() + "\nBruger: " + currentUser.userName.ToString() + "\nDato: " + _date.ToString() + "\nTransactionsID: " + _transactionID.ToString();
        }    
        
        public override bool Execute()
        {
            if ((currentUser.balance > 0 && currentUser.balance + amount < 0) || currentUser.balance <= 0 && amount < 0)
            {
                throw new IllegalCashTransactionException();
            }

            currentUser.balance += amount;
            return true;
        }
    }
}

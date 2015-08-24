using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    abstract class Transaction
    {
        static protected uint _transactionIDCounter;
        protected uint _transactionID;
        protected User _currentUser;
        protected DateTime _date;
        protected decimal _amount;


        public abstract bool Execute();

        public override string ToString()
        {
            return _transactionID.ToString() + _amount.ToString() + _date.ToString();
        }


        public Transaction()
        {
            
        }


        public uint transactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }
        
        public User currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }


        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        
    }
}

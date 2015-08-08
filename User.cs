using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    
    class User// : IComparable
    {
        //Jeg har valgt at benytte uint til mine ID'er, da de alligevel ikke må komme under 0. Herved kan man også have 4.294.967.295 forskellige brugere i stedet for det halve. (ikke at det gør nogen forskel i denne sammenhæng)
        static private uint _userIDCounter = 0;
        private uint _userID;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        //constructor
        public User (string firstName, string lastName, string userNameIn, string email)
        {
            //Her er det vigtigt, at ++ ligger før variablen, da _userIDCounter så bliver talt en op inden den lægges over i _userID.
            _userID = ++_userIDCounter;
            _firstName = firstName;
            _lastName = lastName;
            _userName = userNameIn;
            _email = email;
            _balance = balance;
        }

        public uint userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public override bool Equals(object obj)
        {
            User userObj = obj as User;

            if (obj == null || (Object) userObj == null)
            {
                return false;
            }

            return (this._userID == userObj._userID);
        }

        public override string ToString()
        {
 	        return _firstName + " " + _lastName + " (" + _email + ")";
        }

        public override int GetHashCode()
        {
            return this.userName.GetHashCode() ^ this.firstName.GetHashCode() ^ this.lastName.GetHashCode();
        }

        
    }
}


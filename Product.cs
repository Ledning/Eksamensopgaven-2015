using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class Product
    {
        private uint _productID; //er uint, da ID'et ikke må være negativt.
        private string _name;
        private decimal _price;
        private bool _active;
        private bool _canBeBoughtOnCredit;

        public Product() //Tom default constructor, da SeasonalProduct vil have en constructor uden parametre.
        {

        }

        public Product (uint productID, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            _productID = productID;
            _name = name;
            _price = price;
            _active = active;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        

        public uint productID
        {
            get { return _productID; }
            set { _productID = value; }
        }



        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }

        public bool active
        {
            get { return _active; }
            set { _active= value; }
        }

        public bool canBeBoughtOnCredit
        {
            get { return _canBeBoughtOnCredit; }
            set { _canBeBoughtOnCredit = value; }
        }
    }
}

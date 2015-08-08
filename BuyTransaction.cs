using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class BuyTransaction : Transaction
    {
        private Product _selectedProduct;

        public BuyTransaction (User currentUser, Product selectedProduct)
        {
            _transactionID = ++_transactionIDCounter;
            _currentUser = currentUser;
            _date = DateTime.Now;
            _selectedProduct = selectedProduct;
            _amount = selectedProduct.price;
        }

        public new bool Execute()
        {
            if (currentUser.balance < amount)
            {
                throw new InsufficientCreditsException("Du har ikke råd til denne vare. Indsæt venligst flere penge på din konto og prøv igen.");
            }

            currentUser.balance -= amount;
            return true;
        }
    }
}
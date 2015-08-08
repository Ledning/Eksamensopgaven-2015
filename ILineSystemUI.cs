using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    public interface ILineSystemUI
    {
        string DisplayAddUserExecutor(string wantedString);
        void DisplayUserNotFound(string notFoundUserName);
        void DisplayProductNotFound(uint inputProductID);
        void DisplayUserInfo(string inputUserName);
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage(string notFoundAdminCommand);
        //void DisplayUserBuysProduct(string currentUser, int howMany, Product chosenProduct);
        void DisplayUserBuysProduct(string inputUserName, uint inputProductID);
        void Close();
        void DisplayInsufficientCash();
        void DisplayGeneralError(string errorString);
        void DisplayProductIDNotNumber(string inputThatIsNotNumber);
        void DisplayIllegalCashTransaction(string errorString);
        void DisplayNoProductsFound();
        void DisplayNoUsersFound();
    }
}

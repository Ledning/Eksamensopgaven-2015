using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class LineSystemCommandParser
    {
        LineSystem _lineSystem;
        LineSystemCLI _CLI;
        private Dictionary<string, Action<string[]>> _adminCmd = new Dictionary<string, Action<string[]>>();
        private Dictionary<string, Action<string[]>> _userCmd = new Dictionary<string, Action<string[]>>();

        public LineSystemCommandParser(LineSystemCLI CLI, LineSystem lineSystem)
        {
            _lineSystem = lineSystem;
            _CLI = CLI;
            _adminCmd.Add(":adduser", AddUser);
            _adminCmd.Add(":activate", ActiveProductOnOff);
            _adminCmd.Add(":deactivate", ActiveProductOnOff);
            _adminCmd.Add(":addcash", InsertCashTransactionCmd);
            _adminCmd.Add(":crediton", BoughtOnCreditOnOff);
            _adminCmd.Add(":creditoff", BoughtOnCreditOnOff);
            _adminCmd.Add(":quit", QuitProgram);
        }

        public void ParseCmd(string userInput)
        {
            string[] cmdSplitter = userInput.Split(' ');

            if (cmdSplitter.Count() == 0)
            {
                //Kommer brugeren til at trykke enter uden at have skrevet noget, sker der intet.
            }
            else if (cmdSplitter[0].StartsWith(":"))
            {
                var dictionaryValue = _adminCmd.FirstOrDefault(dv => dv.Key.Equals(cmdSplitter[0]));

                if (dictionaryValue.Value != null)
                {
                    _adminCmd[dictionaryValue.Key].Invoke(cmdSplitter);
                }

                else
                {
                    _CLI.DisplayAdminCommandNotFoundMessage(userInput);
                }
            }

            else
            {
                if (cmdSplitter.Count() == 1)
                {
                    _CLI.DisplayUserInfo(cmdSplitter[0]);
                }

                else if (cmdSplitter.Count() == 2)
                {
                    bool isDigitOnly = true;

                    foreach (char checker in cmdSplitter[1])
                    {
                        if (checker < '0' || checker > '9')
                            isDigitOnly = false;
                    }

                    if (isDigitOnly)
                        _CLI.DisplayUserBuysProduct(cmdSplitter[0], Convert.ToUInt32(cmdSplitter[1]));

                    else
                        _CLI.DisplayProductIDNotNumber(cmdSplitter[1]);
                }

                else if (cmdSplitter.Count() == 3)
                {
                    
                    bool isDigitOnly = true;

                    foreach (char checker in cmdSplitter[1])
                    {
                        if (checker < '0' || checker > '9')
                            isDigitOnly = false;
                    }

                    if (!isDigitOnly)
                        _CLI.DisplayProductIDNotNumber(cmdSplitter[1]);

                    foreach (char checker in cmdSplitter[2])
                    {
                        if (checker < '0' || checker > '9')
                            isDigitOnly = false;
                    }

                    if (!isDigitOnly)
                        _CLI.DisplayProductIDNotNumber(cmdSplitter[2]);

                    foreach (User user in _lineSystem.userList)
	                {
		                if (user.userName == cmdSplitter[0])
                        {
                            foreach (Product product in _lineSystem.productList)
                            {
                                if (product.productID == Convert.ToUInt32(cmdSplitter[2]))
                                {
                                    if (user.balance < (product.price * Convert.ToInt32(cmdSplitter[1])))
                                    {
                                        throw new InsufficientCreditsException("Du har ikke råd til denne vare. Indsæt venligst flere penge på din konto og prøv igen.");
                                    }

                                    for (int i = 0; i < Convert.ToInt32(cmdSplitter[1]); ++i)
                                    {
                                        _lineSystem.BuyProduct(user, product);
                                    }
                                    
                                    BuyTransaction buyTransaction = new BuyTransaction(user, product);
                                    _CLI.DisplayUserBuysProduct(user.userName, Convert.ToInt32(cmdSplitter[1]), product);                                    
                                }
                            }
                        }
	                }                  
                }

                else
                {
                    _CLI.DisplayTooManyArgumentsError();
                }
            }
        }

        public void AddUser(string[] cmdSplitter)
        {
            _lineSystem.userList.Add(_CLI.AddUser());
        }

        public void ActiveProductOnOff (string[] cmdSplitter)
        {
            bool isDigitOnly = true;

            foreach (char checker in cmdSplitter[1])
            {
                if (checker < '0' || checker > '9')
                    isDigitOnly = false;
            }
            if (isDigitOnly)
            {
                foreach (Product item in _lineSystem.productList)
                {
                    if (item.productID == Convert.ToUInt32(cmdSplitter[1]))
                    {
                        if (cmdSplitter[0] == ":activate")
                            item.active = true;
                        else
                            item.active = false;

                        _CLI.DisplayProductList();
                        return;
                    }
                }

                _CLI.DisplayProductNotFound(Convert.ToUInt32(cmdSplitter[1]));
                    
            }

            else
                _CLI.DisplayProductIDNotNumber(cmdSplitter[1]);
        }

        public void InsertCashTransactionCmd (string[] cmdSplitter)
        {
            bool isDigitOnly = true;

            foreach (char checker in cmdSplitter[2])
            {
                if (checker < '0' || checker > '9')
                    isDigitOnly = false;
            }

            if (isDigitOnly)
            {
                foreach (User item in _lineSystem.userList)
                {
                    if (item.userName == cmdSplitter[1])
                    {
                        _lineSystem.AddCreditsToAccount(item, Convert.ToDecimal(cmdSplitter[2]));
                        _CLI.DisplayTransaction();
                        return;
                    }
                }

                _CLI.DisplayUserNotFound(cmdSplitter[1]);
            }

            else
                _CLI.DisplayProductIDNotNumber(cmdSplitter[1]);
        }

        public void BoughtOnCreditOnOff (string[] cmdSplitter)
        {
            foreach (Product item in _lineSystem.productList)
            {
                if (item.productID == Convert.ToUInt32(cmdSplitter[1]))
                {
                    if (cmdSplitter[0] == ":crediton")
                        item.canBeBoughtOnCredit = true;
                    else
                        item.canBeBoughtOnCredit = false;

                    _CLI.DisplayProductList();
                    return;
                }
            }
        }

        public void QuitProgram (string[] cmdSplitter)
        {
            _CLI.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgaven_2015
{
    class LineSystemCLI : ILineSystemUI
    {
        private LineSystem _lineSystem;
        private List<Product> _activeProducts = new List<Product>();

        public LineSystemCLI (LineSystem lineSystem)
        {
            _lineSystem = lineSystem;
        }

        public void RunProgram (LineSystemCommandParser cmdParser)
        {
            _lineSystem.productList = _lineSystem.LoadProductList();
            bool programOn = true;

            while (programOn)
            {
                DisplayProductList();

                try
                {
                    cmdParser.ParseCmd(Console.ReadLine());
                }
                #region Lang Liste af catch
                catch (IllegalCashTransactionException e)
                {
                    Console.Clear();
                    Console.WriteLine("Der opstod en fejl i overførslen:\n" + e.Message);
                }

                catch (InsufficientCreditsException)
                {
                    Console.Clear();
                    Console.WriteLine("Du har ikke nok penge. Indsæt flere på kontoen og prøv igen");
                }

                catch (NoProductsFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("Listen over produkter er væk.");
                }

                catch (NoUsersFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("Der er i øjeblikket ingen brugere registreret.");
                }

                catch (ProductNotFoundException inputProductID)
                {
                    Console.Clear();
                    Console.WriteLine("Det indtastede ID {0} Blev ikke fundet.", inputProductID.Message);
                }

                catch (UserNotFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("Brugeren med dette navn eksisterer ikke.");
                }

                catch (GeneralErrorException e)
                {
                    Console.Clear();
                    Console.WriteLine("Der opstod en fejl.\n" + e);
                }

                catch (AdminCommandNotFoundException notFoundCommand)
                {
                    Console.Clear();
                    Console.WriteLine("Den indtastede adminkommando {0} findes ikke. De eksisterende kommandoer er: :adduser, :activate (efterfulgt af produktID), :deactivate (Efterfulgt af produktID), :addcash (Efterfulgt af brugernavn og beløb), :boughtoncrediton (efterfulgt af produktID), :boughtoncreditoff (efterfulgt af produktID) og :quit", notFoundCommand.Message);
                }

                catch (ProductIDNotNumberException inputThatIsNotNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Den indtastede værdi {0} er ikke et tal", inputThatIsNotNumber.Message);
                }

                catch (TooManyArgumentsErrorException)
                {
                    Console.Clear();
                    Console.WriteLine("Det indtastede input indeholdt for mange argumenter.");
                }

                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                #endregion

                Console.ReadKey();
            }
        }

        public void DisplayProductList()
        {
            Console.Clear();

            foreach (Product item in _lineSystem.productList)
            {
                if (item.active == true)
                {
                    Console.Write(item.productID + "\t" + item.name);
                    Console.CursorLeft = Console.BufferWidth - 35; //Her bliver cursoren flyttet til plads 35 fra højre. på den måde står prisen det samme sted for alle varer.
                    Console.Write(item.price + " kr \n");
                }
            }  
        }

        public void DisplayTransaction ()
        {
            Console.Clear();
            Console.WriteLine("Overførslen er udført.");
        }

        public User AddUser()
        {

            string firstName = DisplayAddUserExecutor("fornavn");
            string lastName = DisplayAddUserExecutor("efternavn");
            string userName = DisplayAddUserExecutor("brugernavn");
            string email = DisplayAddUserExecutor("email");

            User newUser = new User(firstName, lastName, userName, email);
            Console.Clear();
            Console.WriteLine("Brugeren {0} er tilføjet", userName);

            return newUser;
        }

        public string DisplayAddUserExecutor(string wantedString)
        {
            string createdString;
            bool validater = true;

            do
            {
                validater = true;
                Console.Clear();
                Console.WriteLine("Indtast venligst brugerens " + wantedString);
                createdString = Console.ReadLine();

                if (wantedString != "email")
                {
                    foreach (char checker in createdString)
                    {
                        if (wantedString == "fornavn" || wantedString == "efternavn")
                        {
                            if (!Char.IsLetter(checker))
                                validater = false;
                        }

                        else if (wantedString == "brugernavn")
                        {
                            if (!Char.IsLower(checker) && !Char.IsDigit(checker) && checker != '_')
                                validater = false;
                        }
                    }
                }

                else
                {
                    string[] emailSplitter = createdString.Split('@');
                    if (emailSplitter.Count() != 2 || !emailSplitter[1].Contains(".") || emailSplitter[1].StartsWith("-") || emailSplitter[1].StartsWith(".") || emailSplitter[1].EndsWith("-") || emailSplitter[1].EndsWith("."))
                    {
                        validater = false;
                    }

                    foreach (char checker in emailSplitter[0])
                    {
                        if (!Char.IsLetterOrDigit(checker) && checker != '.' && checker != '_' && checker != '-')
                            validater = false;
                    }

                    foreach (char checker in emailSplitter[1])
                    {
                        if (!Char.IsLetterOrDigit(checker) && checker != '.' && checker != '-') //tager ikke højde for at ikkeengelske bogstaver ikke må benyttes.
                            validater = false;
                    }
                }
            }
            while (validater == false);

            return createdString;
        }

        public void DisplayUserNotFound(string notFoundUserName)
        {
            throw new UserNotFoundException();
        }

        public void DisplayProductNotFound(uint inputProductID)
        {
            throw new ProductNotFoundException(Convert.ToString(inputProductID));
        }

        public void DisplayUserInfo(string inputUserName)
        {
            foreach (User user in _lineSystem.userList)
	        {              
                if(user.userName == inputUserName)
                {
                    Console.Clear();
                    Console.WriteLine("Brugernavn: " + user.userName);
                    Console.WriteLine("Navn: {0} {1}", user.firstName, user.lastName);
                    Console.WriteLine("Saldo: " + user.balance);
                    Console.WriteLine("BrugerID: " + user.userID);

                    if (user.balance < 50)
                    {
                        Console.WriteLine("Din saldo er lav. Overvej venligst at indsætte flere penge på kontoen.");
                    }

                    return; 
                }
	        }

            DisplayUserNotFound(inputUserName);
        }

        public void DisplayTooManyArgumentsError()
        {
            throw new TooManyArgumentsErrorException();
        }

        public void DisplayAdminCommandNotFoundMessage(string notFoundAdminCommand)
        {
            throw new AdminCommandNotFoundException(notFoundAdminCommand);
        }

        public void DisplayUserBuysProduct(string currentUser, int howMany, Product chosenProduct)
        {
            Console.Clear();
            Console.WriteLine("Brugeren {0} har købt {1} af {2}", currentUser, howMany, chosenProduct.name);
        }

        public void DisplayUserBuysProduct(string inputUserName, uint inputProductID)
        {
            
            foreach (User user in _lineSystem.userList)
	        {
                if(user.userName == inputUserName)
                {
                    foreach (Product product in _lineSystem.productList)
                    {
                        if(product.productID == inputProductID)
                        {
                            _lineSystem.BuyProduct(user, product);
                            Console.Clear();
                            Console.WriteLine("Produktet er købt");
                            return;
                        }
                    }

                    DisplayProductNotFound(inputProductID);
                    return;
                }
            }

            DisplayUserNotFound(inputUserName);
        }

        public void Close()
        {
            Console.Clear();
            Console.WriteLine("Programmet lukkes.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public void DisplayInsufficientCash()
        {
            throw new InsufficientCreditsException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new GeneralErrorException(errorString);
        }

        public void DisplayProductIDNotNumber (string inputThatIsNotNumber)
        {
            throw new ProductIDNotNumberException(inputThatIsNotNumber);
        }

        public void DisplayIllegalCashTransaction (string errorString)
        {
            throw new IllegalCashTransactionException(errorString);
        }

        public void DisplayNoProductsFound()
        {
            throw new NoProductsFoundException();
        }

        public void DisplayNoUsersFound()
        {
            throw new NoUsersFoundException();
        }
    }
}

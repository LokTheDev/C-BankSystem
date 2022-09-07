using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BankSystem{
    public class BankManageSystem
    {
        private List<UserAccount> accounts = new List<UserAccount>();

        public enum UItype
        {
            LoginView,
            MenuView,
            CreateView,
            SearchView,
            DepositView,
            WithdrawView,
            StateView,
            DeleteView
        }


        public static void Main(string[] args)
        {
            new BankManageSystem().LoginView();
        }

        public void LoginView()
        {
            Console.Clear();
            ShowView(BankManageSystem.UItype.LoginView);
            Console.SetCursorPosition(13, 7);
            string accountname = Console.ReadLine();
            Console.SetCursorPosition(13, 8);
            bool password;
            password = DataValidator.PasswordValidate(accountname);
            if (password)
            {
                new BankManageSystem().MenuView();
            }


        }

        public void MenuView()
        {
            Console.Clear();
            ShowView(BankManageSystem.UItype.MenuView);
            Console.SetCursorPosition(32, 14);
            ConsoleKey option = Console.ReadKey().Key;
            DataValidator.MenuValidate(option);
        }

        public void CreateView()
        {
            Console.Clear();
            ShowView(BankManageSystem.UItype.CreateView);
            Console.SetCursorPosition(15, 7);
            string fName = Console.ReadLine();
            Console.SetCursorPosition(14, 8);
            string lName = Console.ReadLine();
            Console.SetCursorPosition(12, 9);
            string address = Console.ReadLine();
            Console.SetCursorPosition(10, 10);
            string mobile = Console.ReadLine();
            Console.SetCursorPosition(11, 11);
            string email = Console.ReadLine();
            Console.SetCursorPosition(0, 14);
            Console.Write("IS The Information Correct (Y/N)?");
            string confirm = Console.ReadLine();



            switch (confirm)
            {
                case "Y":
                case "y":
                case "":
                    //validate mobile and email
                    if (!DataValidator.MobileValidate(mobile))
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine(" Invalid phone number.");
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        CreateView();
                        return;
                    }
                    if (!DataValidator.EmailValidate(email))
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine(" Invalid Email.");
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        CreateView();
                        return;
                    }
                    DataValidator.CreateValidate(fName, lName, address, mobile, email);
                    break;

                case "N":
                case "n":
                    CreateView();
                    break;
                default:
                    Console.WriteLine("Invalid Key");
                    Console.WriteLine(" Please Try Again (Press Any Key)");
                    Console.ReadKey();
                    CreateView();
                    break;
            }
        }


        public void SearchView()
        {
            Console.Clear();
            ShowView(BankManageSystem.UItype.SearchView);
            Console.SetCursorPosition(19, 7);
            string target = Console.ReadLine();
            Console.SetCursorPosition(0, 11);

            if (target.Length > 10)
            {
                Console.WriteLine("Invalid Account Number (More Than 10 Digits)");
                Console.WriteLine(" Check Another Account (y/n) ?");
                string confirm = Console.ReadLine();

                switch (confirm)
                {
                    case "Y":
                    case "y":
                    case "":
                        new BankManageSystem().SearchView();
                        return;

                    case "N":
                    case "n":
                        new BankManageSystem().MenuView();
                        break;
                    default:
                        Console.WriteLine("Invalid Key");
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        new BankManageSystem().SearchView();
                        break;
                }
                return;
            }
            if (!Int64.TryParse(target, out long longInt))
            {
                Console.WriteLine("Invalid Account Number (Contains Character / Symbol / Empty)");
                Console.WriteLine(" Check Another Account (y/n) ?");
                string confirm = Console.ReadLine();

                switch (confirm)
                {
                    case "Y":
                    case "y":
                    case "":
                        new BankManageSystem().SearchView();
                        return;

                    case "N":
                    case "n":
                        new BankManageSystem().MenuView();
                        break;
                    default:
                        Console.WriteLine("Invalid Key");
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        new BankManageSystem().SearchView();
                        break;
                }
                return;
            }

            int parsedTarget = int.Parse(target);
            DataValidator.SearchValidate(parsedTarget);

        }

        public void DepositView()
        {
            Console.Clear();
            ShowView(BankManageSystem.UItype.DepositView);
            Console.SetCursorPosition(19, 7);
            string target = Console.ReadLine();
            Console.SetCursorPosition(0, 11);

            if (target.Length > 10)
            {
                Console.WriteLine("Invalid Account Number (More Than 10 Digits)");
                Console.WriteLine(" Try Again (y/n) ?");
                string confirm = Console.ReadLine();

                switch (confirm)
                {
                    case "Y":
                    case "y":
                    case "":
                        new BankManageSystem().DepositView();
                        return;

                    case "N":
                    case "n":
                        new BankManageSystem().MenuView();
                        break;
                    default:
                        Console.WriteLine("Invalid Key");
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        new BankManageSystem().DepositView();
                        break;
                }
                return;
            }
            if (!Int64.TryParse(target, out long longInt))
            {
                Console.WriteLine("Invalid Account Number (Contains Character / Symbol / Empty)");
                Console.WriteLine(" Try Again (y/n) ?");
                string confirm = Console.ReadLine();

                switch (confirm)
                {
                    case "Y":
                    case "y":
                    case "":
                        new BankManageSystem().DepositView();
                        return;

                    case "N":
                    case "n":
                        new BankManageSystem().MenuView();
                        break;
                    default:
                        Console.WriteLine("Invalid Key");
                        Console.WriteLine(" Please Try Again (Press Any Key)");
                        Console.ReadKey();
                        new BankManageSystem().DepositView();
                        break;
                }
                return;
            }

            int parsedTarget = int.Parse(target);
            DataValidator.DepositValidate(parsedTarget);
        }


        public void ShowView(BankManageSystem.UItype _type)
        {
            switch (_type)
            {
                case BankManageSystem.UItype.LoginView:
                    Console.WriteLine("  ________________________________________________________");
                    Console.WriteLine(" |                                                        |");
                    Console.WriteLine(" |        WELCOME TO SIMPLE BANK MANAGEMENT SYSTEM        |");
                    Console.WriteLine(" |________________________________________________________|");
                    Console.WriteLine(" |                                                        |");
                    Console.WriteLine(" |                    Log In To Start                     |");
                    Console.WriteLine(" |                                                        |");
                    Console.WriteLine(" | User Name:                                             |");
                    Console.WriteLine(" | Password :                                             |");
                    Console.WriteLine(" |________________________________________________________|");
                    Console.WriteLine();
                    break;

                case BankManageSystem.UItype.MenuView:
                    Console.WriteLine("  _______________________________________________________");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |        WELCOME TO SIMPLE BANK MANAGEMENT SYSTEM       |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |  1. Create a new account                              |");
                    Console.WriteLine(" |  2. Search for an account                             |");
                    Console.WriteLine(" |  3. Deposit                                           |");
                    Console.WriteLine(" |  4. Withdraw                                          |");
                    Console.WriteLine(" |  5. A/C statements                                    |");
                    Console.WriteLine(" |  6. Delete account                                    |");
                    Console.WriteLine(" |  7. Exit                                              |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |    Enter your choice (1 - 7):                         |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine();
                    break;

                case BankManageSystem.UItype.CreateView:
                    Console.WriteLine("  _______________________________________________________");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                 CREATE A NEW ACCOUNT                  |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                   ENTER THE DETAILS                   |");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |  First Name:                                          |");
                    Console.WriteLine(" |  Last Name:                                           |");
                    Console.WriteLine(" |  Address:                                             |");
                    Console.WriteLine(" |  Phone:                                               |");
                    Console.WriteLine(" |  E-mail:                                              |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine();
                    break;
                case BankManageSystem.UItype.SearchView:
                    Console.WriteLine("  _______________________________________________________");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                    SEARCH AN ACCOUNT                  |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                   ENTER THE DETAILS                   |");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |  Account Number:                                      |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine();
                    break;
                case BankManageSystem.UItype.DepositView:
                    Console.WriteLine("  _______________________________________________________");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                        DEPOSIT                        |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |                   ENTER THE DETAILS                   |");
                    Console.WriteLine(" |                                                       |");
                    Console.WriteLine(" |  Account Number:                                      |");
                    Console.WriteLine(" |  Amount: $                                            |");
                    Console.WriteLine(" |_______________________________________________________|");
                    Console.WriteLine();
                    break;
            }


        }


    }
}
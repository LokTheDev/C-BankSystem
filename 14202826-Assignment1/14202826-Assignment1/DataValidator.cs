using System;
using System.IO;
using static System.Console;

namespace BankSystem;

public static class DataValidator
{
    public static bool PasswordValidate(string _userName)
    {
        ConsoleKeyInfo key;
        string result = "";
        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Backspace && result.Length > 0)
            {
                result = result.Remove(result.Length - 1);
                Console.Write("\b \b");
            }
            else if (key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.Enter &&
                     key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Tab &&
                     key.Key != ConsoleKey.Backspace && key.KeyChar != '\u0000')
            {
                result += key.KeyChar;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);


        string[] existedAccount = File.ReadAllLines("login.txt");
        string symbol = "|";

        for (int i = 0; i < existedAccount.Length; i++)
        {
            string[] userRow = existedAccount[i].Split(symbol);
            string userName = (userRow[0]);
            string userPW = userRow[1];
            if (result == userPW && userName == _userName)
            {
                return true;
            }
        }
        Console.SetCursorPosition(0, 11);
        Console.WriteLine("Incorrect User Info, Click Any Key to Try Again.");
        Console.ReadKey();
        new BankManageSystem().LoginView();

        return false;
    }

    public static void MenuValidate(ConsoleKey _option)
    {
        switch (_option)
        {
            case ConsoleKey.D1:
                new BankManageSystem().CreateView();
                break;
            case ConsoleKey.D2:
                new BankManageSystem().SearchView();
                break;
            case ConsoleKey.D3:
                new BankManageSystem().DepositView();
                break;
            case ConsoleKey.D4:
                //go create view
                break;
            case ConsoleKey.D5:
                //go create view
                break;
            case ConsoleKey.D6:
                //go create view
                break;
            case ConsoleKey.D7:
                new BankManageSystem().LoginView();
                break;
            default:
                Console.SetCursorPosition(0, Console.CursorTop + 3);
                Console.WriteLine("Invalid Input, Click Any Key to Try Again.");
                Console.ReadKey();
                new BankManageSystem().MenuView();
                break;
        }
    }

    public static Boolean MobileValidate(string _mobile)
    {
        if (_mobile.Length > 10 || _mobile.Length <= 0)
        {
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("Phone Number Is Too Short (<0) Or Too Long (> 10)");
            return false;
        }
        else if (!Int64.TryParse(_mobile, out long longInt))
        {
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("Phone Number Contain Invalid Character!");
            return false;
        }

        return true;
    }

    public static Boolean EmailValidate(string _email)
    {

        if (_email.Contains("@"))
        {
            return true;
        }
        return false;
    }



    public static void CreateValidate(string _fName, string _lName, string _address, string _mobile, string _email)
    {
        //create new txt
        string path = Directory.GetCurrentDirectory();
        int accountNumber;
        do
        {
            accountNumber = new Random().Next(100000, 99999999);
        } while (File.Exists((path + "/" + accountNumber + ".txt")));

        UserAccount newUser = new UserAccount(accountNumber, 0, _fName, _lName, _address, _mobile, _email);
        newUser.CreateLog();
        EmailFunction SendEmail = new EmailFunction();

        if (SendEmail.NewUserEmail(_email, _lName + _fName, _address, accountNumber))
        {
            Console.WriteLine("Account Created. Detail Will Be Provided Via Email");
        }
        else
        {
            Console.WriteLine("Account Created. But Failed To Send Email!");
        }
        Console.WriteLine("Account Created. Your Account Number: " + accountNumber);

        Console.WriteLine("Click Any Key To Return To The Menu");
        Console.ReadKey();
        new BankManageSystem().MenuView();

    }

    public static void SearchValidate(int _target)
    {
        string fName, lName, address, mobile, email, accountno, total;
        var userInfo = new List<string>();
        string path = Directory.GetCurrentDirectory();
        if (File.Exists((path + "/" + _target + ".txt"))) {
            string[] AccountInfo = File.ReadAllLines(path + "/" + _target + ".txt");
            string symbol = "|";

            for (int i = 0; i < AccountInfo.Length; i++)
            {
                userInfo.Add(AccountInfo[i].Split(symbol)[1]);

            }
            Console.WriteLine("  !ACCOUNT FOUND!                                        ");
            Console.WriteLine("  _______________________________________________________");
            Console.WriteLine(" |                                                       |");
            Console.WriteLine(" |                    ACCOUNT DETAILS                    |");
            Console.WriteLine(" |_______________________________________________________|");
            Console.WriteLine(" |                                                       |");
            Console.WriteLine(" |                                                       |");
            Console.WriteLine(" |  First Name:" + userInfo[0].PadRight(36, ' ') + "      |");
            Console.WriteLine(" |  Last Name:" + userInfo[1].PadRight(36, ' ') + "       |");
            Console.WriteLine(" |  Address:" + userInfo[2].PadRight(36, ' ') + "         |");
            Console.WriteLine(" |  Phone:" + userInfo[3].PadRight(36, ' ') + "           |");
            Console.WriteLine(" |  Email:" + userInfo[4].PadRight(36, ' ') + "           |");
            Console.WriteLine(" |  AccountNo:" + userInfo[5].PadRight(36, ' ') + "       |");
            Console.WriteLine(" |_______________________________________________________|");
            Console.WriteLine();

            Console.SetCursorPosition(0, 20);
            Console.Write("CHECK ANOTHER ACCOUNT (y/n)?");
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
        }
        else
        {
            Console.SetCursorPosition(0, 13);
            Console.Write("ACCOUNT NOT FOUND");
            Console.SetCursorPosition(0, 14);
            Console.Write("CHECK ANOTHER ACCOUNT (y/n)?");
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
        }

    }

    public static void DepositValidate(int _target)
    {
        string path = Directory.GetCurrentDirectory();
        if (File.Exists((path + "/" + _target + ".txt")))
        {
            Console.WriteLine("ACCOUNT FOUND PLEASE ENTER AMOUNT.....");
            Console.SetCursorPosition(13, 8);
            string amount = Console.ReadLine();

            Statement transaction = new Statement();
            if(transaction.Deposit(amount, _target))
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Deposit Is Sucessful!");
                Console.ReadKey();
                new BankManageSystem().MenuView();
            }
            else
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Input Invalid, Please Try again!");
                Console.ReadKey();
                new BankManageSystem().DepositView();
            }


        }
        else
        {
            Console.SetCursorPosition(0, 14);
            Console.Write("ACCOUNT NOT FOUND");
            Console.SetCursorPosition(0, 15);
            Console.Write("Retry (y/n)?");
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
        }

    }

}






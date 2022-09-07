using System;
using System.IO;
using static System.Console;

namespace BankSystem;
//5133307

public class Statement
{


    public enum StatementType
    {
        DepositLog,
        WithdrawalLog
    }

    public bool Deposit(string _amount, int _accountnumber)
    {
        int value = 0;
        int NewSum;
        int parseAmount;
        if (!Int64.TryParse(_amount, out long longInt))
        {
            return false;
        }

        int x = 0;
        string[] TextFile = File.ReadAllLines(_accountnumber+".txt");
        string CurrentAmount = TextFile[6].Split("|")[1];

        if (int.TryParse(_amount, out x) && int.TryParse(CurrentAmount, out x))
        {
            parseAmount = int.Parse(_amount);
            NewSum = parseAmount + int.Parse(CurrentAmount);

        }
        else return false;

        TextFile[7 - 1] = "Balance|" + NewSum;
        File.WriteAllLines(_accountnumber + ".txt", TextFile);
        UpdateLog(_accountnumber, parseAmount, NewSum, StatementType.DepositLog);
        return true;
    }

    //todo
    public void Withdrawal(string _amount, int _accountnumber)
    {
        
    }

    public void UpdateLog(int _accountnumber, int _amount, int sum,StatementType _type)
    {
        switch (_type)
        {
            case StatementType.DepositLog:
                string path = Directory.GetCurrentDirectory();
                string file = path + "/"+_accountnumber+".txt";
                string log = "Deposit|$" + _amount + "|Balance|$" + sum;
                File.AppendAllText(file, log);
                break;

            case StatementType.WithdrawalLog:
                
                break;
        }
    }


}






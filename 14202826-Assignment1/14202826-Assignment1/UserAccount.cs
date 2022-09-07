using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace BankSystem
{
    public class UserAccount
    {

        private int accountNumber;
        private float total;
        private string fName, lName, address, mobileNumber, email;
        //private List<Record> records;

        public UserAccount(int _accountNumber, float _total, string _fName, string _lName,
                           string _address, string _mobileNumber, string _email/*, acType type*/)
        {
            this.accountNumber = _accountNumber;
            this.total = _total;
            this.fName = _fName;
            this.lName = _lName;
            this.address = _address;
            this.mobileNumber = _mobileNumber;
            this.email = _email;
            //records = new List<Record>();

            //if (type == AccountType.New)
            //{
            //    statement.Add(new Transaction(DateTime.Now, "Opening Balance", 0, 0, balance));
            //    statement.Add(new Transaction(DateTime.Now, "Closing Balance", 0, 0, balance));
            //}

        }

        public void CreateLog()
        {
            string path = Directory.GetCurrentDirectory();
            TextWriter tw = new StreamWriter(path+"/"+this.accountNumber+".txt", true);
            tw.WriteLine("First Name|"+this.fName);
            tw.WriteLine("Laset Name|" + this.lName);
            tw.WriteLine("Adress|" + this.address);
            tw.WriteLine("Phone|" + this.mobileNumber);
            tw.WriteLine("Email|" + this.email);
            tw.WriteLine("AccountNo|" + this.accountNumber);
            tw.WriteLine("Balance|" + this.total);
            tw.Close();
            
        }


    }
}


using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace BankSystem
{
    public class EmailFunction
    {
        public bool NewUserEmail(string email, string _name,string _address,int _AccountNumber)
        {

        string To = email;
        string From = "utsappdev2022@gmail.com";
        string GoogleAppPassword = "ybrtbqhbixwupbcf";
        var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(From, GoogleAppPassword),
                EnableSsl = true,
            };
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(From),
                    Subject = "UTS C# DEV SIMPLE BANK",
                    Body = "<h1>HERE IS YOUR INFO</h1>" +
                    "<ul>" +
                    "<li>First Name:</li>"+ _name +
                    "<li>Address</li>" + _address +
                    "<li>Account Number</li>" + _AccountNumber +
                    "</ul>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(To);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
           
        }

        //other function....



    }
}


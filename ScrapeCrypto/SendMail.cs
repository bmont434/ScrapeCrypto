using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ScrapeCrypto
{
    public class Mail
    {
        public void SendEmail(string coin)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("rickv4555@gmail.com");
            mail.From = new MailAddress("rickv4555@gmail.com");
            mail.Subject = "Crytpo Urgent!";
            mail.Body = "The Price of " + coin + " has gone below the Threshold";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("rickv4555@gmail.com", "/*password goes here*/");
            smtp.Send(mail);
        }
    }
}

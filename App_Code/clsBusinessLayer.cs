// namespace initialization
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{
    public clsBusinessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool SendEmail(string Sender, string Recipient, string bcc, string cc,
    string Subject, string Body)
    {
        try
        {
            // initiating new MailMessage object called MyMailMessage
            MailMessage MyMailMessage = new MailMessage();
            // assigning Sender argument to From property
            MyMailMessage.From = new MailAddress(Sender);
            // assigning Receipient argument to To property
            MyMailMessage.To.Add(new MailAddress(Recipient));
            // checking if bcc argument is empty and null
            if (bcc != null && bcc != string.Empty)
            {
                // if bcc is not empty and null, pass Bcc argument to Bcc property
                MyMailMessage.Bcc.Add(new MailAddress(bcc));
            }
            // checking if cc argument is empty and null
            if (cc != null && cc != string.Empty)
            {
                // if cc is not empty and null, pass cc argument to CC property
                MyMailMessage.CC.Add(new MailAddress(cc));
            }
            // passing Subject argument to Subject property
            MyMailMessage.Subject = Subject;
            // passing Body argument to Body property
            MyMailMessage.Body = Body;
            // message body in Html
            MyMailMessage.IsBodyHtml = true;
            // set normal to mail priority
            MyMailMessage.Priority = MailPriority.Normal;
            // initiating new SmtpClient object MySmtpClient with "localhost" constructor
            SmtpClient MySmtpClient = new SmtpClient("localhost");
            //SMTP Port = 25;
            //Generic IP host = "127.0.0.1";
            //senging MyMailMessage object through MySmtpClient object 
            MySmtpClient.Send(MyMailMessage);
            // returns true if email is sent
            return true;
        }
        catch (Exception ex)
        {
            // returns false if email is not sent
            return false;
        }
    }
}
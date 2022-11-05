using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace EmailClientLibrary
{
    public class EmailClient
    {
        private static string recipient;
        private static MimeMessage message;

        public static string TestSendEmail()
        {
            string log = "";
            message = new MimeMessage();

            message.From.Add(new MailboxAddress("Margret", "margret76@ethereal.email"));

            //Sending to test email for now, will swap with destination address from input
            message.To.Add(MailboxAddress.Parse("margret76@ethereal.email"));

            message.Subject = "Whoa! It worked!!!";

            message.Body = new TextPart("plain")
            {
                Text = @"Yes,
                   Hello West World..."
            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                client.Authenticate("margret76@ethereal.email", "u5aTHzneNVSzfSXapp");
                Console.WriteLine("Just tried login");
                client.Send(message);
                log += "\nJust tried send " + message.Body.ToString();
            }
            catch (Exception ex)
            {
                log += "\n" + ex.Message;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
                log += "\nComplete";
            }
            return log;
        }

        public void CreateEmail(string subject, string body)
        {
            message = new MimeMessage();

            message.From.Add(new MailboxAddress("Margret", "margret76@ethereal.email"));

            //Sending to test email for now, will swap with destination address from input
            message.To.Add(MailboxAddress.Parse("margret76@ethereal.email"));

            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = @body
            };
        }

        public void SendEmail()
        {
            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.ethereal.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("margret76@ethereal.email", "u5aTHzneNVSzfSXapp");
                Console.WriteLine("Just tried login");
                client.Send(message);
                Console.WriteLine("Just tried send " + message.Body.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
                Console.WriteLine("Complete");
            }
        }

        public void SetRecipient(string recipient)
        {
            
        }

        private void LogInfo()
        {
            //Setup Logging class
            //Get log path from config
        }

        private void ResetClient()
        {

        }
    }
}
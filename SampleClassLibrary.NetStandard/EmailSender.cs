using System;
using System.Net.Mail;
using System.Text;

namespace SampleClassLibrary.NetStandard
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailSender(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration; 
        }

        public string SendEmail(string recipient, string subject, string body)
        {
            StringBuilder failedMessages = new StringBuilder();
            StringBuilder recipientList = new StringBuilder();

            var message = new MailMessage();
            try
            {
                message.To.Add(new MailAddress(recipient));
                message.From = new MailAddress(_emailConfiguration.SenderEmail);

                message.Subject = subject;
                message.Body = body;
                 message.IsBodyHtml = true;

                //send the message
                SmtpClient smtpMail = new SmtpClient(_emailConfiguration.SmtpServer)
                {
                    Port = _emailConfiguration.SmtpPort,
                    EnableSsl = false,
                    Credentials = new System.Net.NetworkCredential(_emailConfiguration.SmtpServerUserName,
                        _emailConfiguration.SmtpServerPassword)
                };
                smtpMail.Send(message);
            }

            catch (Exception ex)
            {
                failedMessages.Append(recipientList + ex.Message);
                throw new Exception("Error getting LogInformation record.");
            }

            return failedMessages.ToString();
        }
    }
}

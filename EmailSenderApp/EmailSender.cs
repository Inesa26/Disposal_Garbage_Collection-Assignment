using System.Net;
using System.Net.Mail;

namespace DisposalApplication
{
    public class EmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender()
        {
            _emailConfig = new EmailConfiguration();
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            // Configure SMTP client
            using (SmtpClient smtpClient = new SmtpClient(_emailConfig.SmtpHost, _emailConfig.SmtpPort))
            {
                smtpClient.EnableSsl = _emailConfig.EnableSsl;
                smtpClient.Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);

                // Create and send mail message
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_emailConfig.SmtpUsername);
                    mailMessage.To.Add(new MailAddress(recipientEmail));
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Email sent successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email: {ex.Message}");
                    }

                    //also I could create SmtpClient and MailMessage objects without 'using', and in this case I should close it in finally block using method dispose();
                }
            }
        }
    }
}
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Models;

namespace SixBDigital.CarValeting.Infrastructure.Email
{
    public class EmailClient : IEmailClient
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailClient(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void SendApprovedEmail(int id, string name, string email)
        {
            if (!_emailConfiguration.Active) return;

            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(name, email));
            message.From.Add(new MailboxAddress(_emailConfiguration.FromName, _emailConfiguration.FromEmail));

            message.Subject = $"Your booking number {id} was approved!";
                
            //TODO: change body with booking info
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = ""
            };
                
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}

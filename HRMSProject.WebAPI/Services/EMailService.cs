using HRMSProject.WebAPI.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace HRMSProject.WebAPI.Services
{
    public class EMailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EMailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(SendEmail request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

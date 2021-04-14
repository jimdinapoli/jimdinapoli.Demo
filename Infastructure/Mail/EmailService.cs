using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SkullJocks.BenAdmin.Application.Contracts.Infastructure;
using SkullJocks.BenAdmin.Application.Models.Mail;
using System.Net;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Infastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.Recipient);
            var body = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
            var response = await client.SendEmailAsync(message);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}

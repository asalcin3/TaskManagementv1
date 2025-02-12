using brevo_csharp.Api;
using brevo_csharp.Model;
using Microsoft.Extensions.Options;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Configuration;

namespace TaskManagement.Infrastructure.Brevo
{

    public class BrevoEmailService : IBrevoEmailService
    {
        private readonly brevo_csharp.Client.Configuration _brevoConfig;
        private readonly BrevoConfig _brevoAppSettings;

        public BrevoEmailService(brevo_csharp.Client.Configuration brevoConfig, IOptions<BrevoConfig> brevoConfigOptions)
        {
            _brevoConfig = brevoConfig;
            _brevoAppSettings = brevoConfigOptions.Value;
        }
        public async Task<string> SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            // Create an instance of the transactional email API
            var emailApi = new TransactionalEmailsApi(_brevoConfig);

            var sender = new BrevoConfig
            {
                DefaultFrom = _brevoAppSettings.DefaultFrom,
                DefaultFromName = _brevoAppSettings.DefaultFromName

            };
            
            // Build the email object
            var sendSmtpEmail = new SendSmtpEmail(
                to: new List<SendSmtpEmailTo> { new SendSmtpEmailTo(toEmail) },
                sender: new SendSmtpEmailSender(sender.DefaultFromName, sender.DefaultFrom),
                subject: subject,
                htmlContent: htmlContent
            );

            try
            {
                // Send the email
                var response = await emailApi.SendTransacEmailAsync(sendSmtpEmail);

                // response.MessageId or other fields can be used as needed
                return response.MessageId;
            }
            catch (Exception ex)
            {
                // Log, re-throw, or handle as appropriate
                throw new InvalidOperationException("Error sending Brevo email", ex);
            }
        }
    }
}

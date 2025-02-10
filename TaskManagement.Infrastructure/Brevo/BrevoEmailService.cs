using brevo_csharp.Api;
using brevo_csharp.Client;
using brevo_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Brevo
{
    public interface IBrevoEmailService
    {
        /// <summary>
        /// Sends an email using Brevo (SendinBlue).
        /// </summary>
        /// <param name="toEmail">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">HTML body content</param>
        /// <returns>Message ID or some result info</returns>
        Task<string> SendEmailAsync(string toEmail, string subject, string body);
    }
    public class BrevoEmailService : IBrevoEmailService
    {
        private readonly Configuration _brevoConfig;

        public BrevoEmailService(Configuration brevoConfig)
        {
            _brevoConfig = brevoConfig;
        }
        public async Task<string> SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            // Create an instance of the transactional email API
            var emailApi = new TransactionalEmailsApi(_brevoConfig);

            // Build the email object
            var sendSmtpEmail = new SendSmtpEmail(
                to: new List<SendSmtpEmailTo> { new SendSmtpEmailTo(toEmail) },
                sender: new SendSmtpEmailSender("your@domain.com", "Your Name"),
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

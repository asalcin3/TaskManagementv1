namespace TaskManagement.Domain.Interfaces
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
}

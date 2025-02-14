using Microsoft.Extensions.Options;
using TaskManagement.Application.Options;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Application.Services
{
    public interface IMessagesService
    {
        public Task SentTaskEmail(long taskId, EEmailTemplate emailTemplate);
    }
    public class MessagesService : IMessagesService
    {
        private readonly ITaskAssigneesRepository _taskAssigneesRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IBrevoEmailService _brevoEmailService;
        private readonly FrontEndHost _frontEndHost;
        private readonly IMessageRepository _messageRepository;
        
        public MessagesService(
            ITaskAssigneesRepository taskAssigneesRepository,
            IMessageRepository messageRepository, 
            IEmailTemplateRepository emailTemplateRepository, 
            IBrevoEmailService brevoEmailService, IOptions<FrontEndHost> options)
        {
            _taskAssigneesRepository = taskAssigneesRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _messageRepository = messageRepository;
            _brevoEmailService = brevoEmailService;
            _frontEndHost = options.Value;
        }

        public async Task SentTaskEmail(long taskId, EEmailTemplate emailTemplate)
        {
            var recipients = await _taskAssigneesRepository.GetAssigneesByTaskId(taskId);
            var taskEmailTemplate = await _emailTemplateRepository.GetEmailTemplate(emailTemplate);
            var messageBody = PopulateBodyMessage(taskEmailTemplate, taskId);
            var messages = new List<Message>();

            foreach (var recipient in recipients)
            {
                var message = await SendEmailToRecipient(recipient, taskEmailTemplate, messageBody);
                messages.Add(message);
            }

            await _messageRepository.InsertMessages(messages);

        }

        private string PopulateBodyMessage(EmailTemplates emailTemplate, long taskId )
        {
            var body = "";
            var taskUrl = $"{_frontEndHost.Url}/{taskId}";
            if (emailTemplate.EmailTemplate == EEmailTemplate.TaskCreated || emailTemplate.EmailTemplate == EEmailTemplate.TaskCompleted)
            {
                // Task on your name is created, Check it out.
                //Task on your name with id was deleted.
                //Task on your name was completed, check it out
                body = emailTemplate.Body
                   .Replace("%taskLink%", taskUrl);
            }
            else if (emailTemplate.EmailTemplate == EEmailTemplate.TaskDeleted)
            {
                body = emailTemplate.Body
                    .Replace("%taskId%", $"{taskId}");
            }
            return body;
        }

        private async Task<Message> SendEmailToRecipient(User recipient, EmailTemplates taskEmailTemplate, string messageBody)
        {
            try
            {
                var messageId = await _brevoEmailService.SendEmailAsync(recipient.Email, taskEmailTemplate.Subject, messageBody);

                return new Message
                {
                    Subject = taskEmailTemplate.Subject,
                    Body = messageBody,
                    Status = string.IsNullOrEmpty(messageId) ? EMessageStatus.Error : EMessageStatus.Sent,
                    WasSentOn = string.IsNullOrEmpty(messageId) ? null : DateTime.Now,
                    ReceiverId = recipient.Id,
                    EmailTemplateType = taskEmailTemplate.EmailTemplate,
                    DeliveryMethod = EDeliveryMethod.Brevo,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email to {recipient.Email}: {ex.Message}");

                return new Message
                {
                    Subject = taskEmailTemplate.Subject,
                    Body = messageBody,
                    Status = EMessageStatus.NotSent,
                    ReceiverId = recipient.Id,
                    EmailTemplateType = taskEmailTemplate.EmailTemplate,
                    DeliveryMethod = EDeliveryMethod.Brevo
                };
            }
        }
    }
}

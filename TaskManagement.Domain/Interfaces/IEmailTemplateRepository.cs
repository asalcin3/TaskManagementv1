using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Interfaces
{
    public interface IEmailTemplateRepository
    {
        public Task<EmailTemplates> GetEmailTemplate(EEmailTemplate emailTemplate);
    }
}

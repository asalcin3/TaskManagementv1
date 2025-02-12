using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Repositories.EmailTemplateRepository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly TMContext _context;

        public EmailTemplateRepository(TMContext context)
        {
            _context = context;
        }
        public async Task<EmailTemplates> GetEmailTemplate(EEmailTemplate emailTemplate)
        {
            var template = await _context.EmailTemplates.SingleOrDefaultAsync(e => e.EmailTemplate == emailTemplate);

            if (template == null)
                throw new NotFoundException($"EmailTemplate {(int)emailTemplate} does not exist in the database");

            return template;
        }
    }
}

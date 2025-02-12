using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TMContext _context;

        public MessageRepository(TMContext context)
        {
            _context = context;
        }

        public async Task InsertMessages(List<Message> messages)
        {
            await _context.Messages.AddRangeAsync(messages);
            await _context.SaveChangesAsync();
        }
    }
}

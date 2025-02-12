using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task InsertMessages(List<Message> messages);

    }
}

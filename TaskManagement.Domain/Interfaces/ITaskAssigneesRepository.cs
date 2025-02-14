using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskAssigneesRepository
    {
        public Task<List<User>> GetAssigneesByTaskId(long id);
        public Task AssignUsersToTask(List<long> ids, long taskId);
    }
}

using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskAssigneesRepository
    {
        public Task<List<User>> GetAssigneesByTaskId(long id);
    }
}

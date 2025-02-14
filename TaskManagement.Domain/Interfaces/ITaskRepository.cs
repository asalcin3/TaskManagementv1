using EntityTask = TaskManagement.Domain.Entities.Task;
using SystemTask = System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces {
    public interface ITaskRepository 
    {
        SystemTask.Task<IEnumerable<EntityTask>> GetAllTasksAsync();
        SystemTask.Task<EntityTask> GetTaskWithAssigneesAsync(long taskId);
        SystemTask.Task<EntityTask?> GetTaskById(long taskId);
        SystemTask.Task<EntityTask>InsertTask(EntityTask task);
        SystemTask.Task<List<EntityTask>> DeleteTask(long taskId);
        SystemTask.Task UpdateTask(EntityTask task);

    }
}

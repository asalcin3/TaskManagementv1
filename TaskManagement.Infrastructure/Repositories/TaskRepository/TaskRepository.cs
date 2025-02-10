
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;
using EntityTask = TaskManagement.Domain.Entities.Task;
using SystemTask = System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Repositories.TaskRepository
{
    public class TaskRepository(TMContext context) : ITaskRepository
    {
        private  readonly TMContext _context = context;

        public async SystemTask.Task<IEnumerable<EntityTask>> GetAllTasksAsync()
        {
            return await _context.Tasks.Include(ta => ta.Assignees).ToListAsync();
        }
        public async SystemTask.Task<EntityTask?> GetTaskById(long taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async SystemTask.Task InsertTask(EntityTask task)
        {
             context.Add(task);
             await _context.SaveChangesAsync();
        }

        public async SystemTask.Task<List<EntityTask>> DeleteTask(long taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            context.Remove(task);
            await _context.SaveChangesAsync();
            return GetAllTasksAsync().Result.ToList();
        }

        public async SystemTask.Task UpdateTask(EntityTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

    }
}

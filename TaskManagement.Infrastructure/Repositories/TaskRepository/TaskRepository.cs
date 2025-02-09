
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
            return await _context.Tasks.ToListAsync();
        }
        public async SystemTask.Task<EntityTask?> GetTaskById(int taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async SystemTask.Task InsertTask(EntityTask task)
        {
             context.Add(task);
             await _context.SaveChangesAsync();
        }

        public async SystemTask.Task DeleteTask(int taskId)
        {
            var task = GetTaskById(taskId);
            context.Remove(task);
        }

        public async SystemTask.Task UpdateTask(EntityTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

    }
}

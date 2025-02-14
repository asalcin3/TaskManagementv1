using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repositories.AssigneeRepository
{
    public class TaskAssigneesRepository : ITaskAssigneesRepository
    {
        private readonly TMContext _context;

        public TaskAssigneesRepository(TMContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAssigneesByTaskId(long id)
        {
            return await _context.TaskAssignees
                .AsNoTracking()
                .Include(t => t.User)
                .Where(t => t.TaskId == id && t.User.Email != null)
                .Select(t => new User
                {
                    Id = t.UserId,
                    UserName = t.User.UserName,
                    Email = t.User.Email,

                })
                .ToListAsync();
        }

        public async Task AssignUsersToTask(List<long> userIds, long taskId)
        {
          
            var existingAssignees = await _context.TaskAssignees
                .Where(ta => ta.TaskId == taskId)
                .Select(ta => ta.UserId)
                .ToListAsync();


            await _context.TaskAssignees
                .Where(ta => ta.TaskId == taskId && !userIds.Contains(ta.UserId))
                .ExecuteDeleteAsync();

       
            var newAssignees = userIds
                .Where(userId => !existingAssignees.Contains(userId))
                .Select(userId => new TaskAssignee { TaskId = taskId, UserId = userId })
                .ToList();

            if (newAssignees.Any())
            {
                await _context.TaskAssignees.AddRangeAsync(newAssignees);
                await _context.SaveChangesAsync();
            }

        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;

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
    }
}

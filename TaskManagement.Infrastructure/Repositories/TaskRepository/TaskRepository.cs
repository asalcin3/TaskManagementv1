﻿
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

        public async Task<EntityTask> GetTaskWithAssigneesAsync(long taskId)
        {
            return await _context.Tasks
                .Include(ta => ta.Assignees)
                .ThenInclude(u => u.User)
                .AsNoTracking()
                .AsSplitQuery()
                .Where(t => t.Id == taskId)
                .SingleOrDefaultAsync() ?? throw new ("Task not found");
        }

        public async SystemTask.Task<EntityTask?> GetTaskById(long taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async SystemTask.Task<EntityTask> InsertTask(EntityTask task)
        {
             var taskDb = context.Add(task);
             await _context.SaveChangesAsync();
             return taskDb.Entity;
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

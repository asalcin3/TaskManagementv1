using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Common.Mappers;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(long taskId);
        Task CreateTaskAsync(CreateTaskDTO dto);
        Task DeleteTaskAsync(long taskId);
    }
    public class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks.Select(t => t.ToDto()).ToList();
        }

     
        public async Task<TaskDTO> GetTaskByIdAsync(long id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task is null) throw new ArgumentException("Task with that id is not found");
          
            return task.ToDto();

        }

        public async Task CreateTaskAsync(CreateTaskDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title can't be empty");
             await _taskRepository.InsertTask(dto.MapCreateTask());
        }

        public async Task DeleteTaskAsync(long taskId)
        {
            await _taskRepository.DeleteTask(taskId);
        }
    }
}

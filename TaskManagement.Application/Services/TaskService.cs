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
    }
    public class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks.Select(t => TasksMapper.ToDto(t)).ToList();
        }
    }
}

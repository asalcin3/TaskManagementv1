using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Common.Mappers;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(long taskId);
        Task CreateTaskAsync(CreateTaskDTO dto);
        Task UpdateTaskAsync(long id, TaskDTO dto);
        Task<List<TaskDTO>> DeleteTaskAsync(long taskId);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserService _userService;
        private readonly IMessagesService _messagesService;

        public TaskService(
            ITaskRepository taskRepository, 
            IUserService userService, 
            IMessagesService messagesService
            )
        {
            _taskRepository = taskRepository;
            _userService = userService;
            _messagesService = messagesService;
        }

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks.Select(t => t.ToDto()).ToList();
        }

     
        public async Task<TaskDTO> GetTaskByIdAsync(long id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task is null) throw new TaskNotFoundException("Task with that id does not exist");
          
            return task.ToDto();

        }

        public async Task CreateTaskAsync(CreateTaskDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title can't be empty");
            if (string.IsNullOrEmpty(dto.Description)) throw new ArgumentException("Description can't be empty");

            var createdTask = await _taskRepository.InsertTask(dto.MapCreateTask());
            await _messagesService.SentTaskEmail(createdTask.Id, EEmailTemplate.TaskCreated);
        }
        public async Task UpdateTaskAsync(long id, TaskDTO dto)
        {
            var taskFromDb = await _taskRepository.GetTaskById(id);
            if (taskFromDb is null) throw new TaskNotFoundException("Task with that ID does not exist");
            if (taskFromDb.Title != dto.Title)
            {
                taskFromDb.Title = dto.Title;
            }

            if (taskFromDb.Description != dto.Description)
            {
                taskFromDb.Description = dto.Description;
            }
            if(taskFromDb.IsCompleted != dto.IsCompleted) {

                taskFromDb.IsCompleted = dto.IsCompleted;
                
                if (taskFromDb.IsCompleted)
                {
                    await _messagesService.SentTaskEmail(taskFromDb.Id, EEmailTemplate.TaskCompleted);
                }
            }

            await _taskRepository.UpdateTask(taskFromDb);
        }
        public async Task<List<TaskDTO>> DeleteTaskAsync(long taskId)
        {
            var tasks = await _taskRepository.DeleteTask(taskId);
            await _messagesService.SentTaskEmail(taskId, EEmailTemplate.TaskDeleted);
            return tasks.Select(t => t.ToDto()).ToList();
        }
    }
}

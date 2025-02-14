using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Common.Mappers;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Interfaces;
using static TaskManagement.Application.Common.DTOs.TaskDTO;

namespace TaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(long taskId);
        Task CreateTaskAsync(TaskDTO.CreateTaskDTO dto);
        Task UpdateTaskAsync(long id, UpdateTaskDTO dto);
        Task<List<TaskDTO>> DeleteTaskAsync(long taskId);
        Task<TaskDTO> GetTaskWithAssigneesAsync(long taskId);
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserService _userService;
        private readonly IMessagesService _messagesService;
        private readonly ITaskAssigneesRepository _taskAssigneesRepository;

        public TaskService
        (
            ITaskRepository taskRepository,
            IUserService userService,
            IMessagesService messagesService, 
            ITaskAssigneesRepository taskAssigneesRepository
        )
        {
            _taskRepository = taskRepository;
            _userService = userService;
            _messagesService = messagesService;
            _taskAssigneesRepository = taskAssigneesRepository;
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

        public async Task CreateTaskAsync(TaskDTO.CreateTaskDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new TaskRequired("Title can't be empty");
            if (string.IsNullOrEmpty(dto.Description)) throw new TaskRequired("Description can't be empty");

            var createdTask = await _taskRepository.InsertTask(dto.MapCreateTask());
            await _messagesService.SentTaskEmail(createdTask.Id, EEmailTemplate.TaskCreated);
        }
        public async Task UpdateTaskAsync(long id, UpdateTaskDTO dto)
        {
            var taskFromDb = await _taskRepository.GetTaskWithAssigneesAsync(id);
            if (taskFromDb is null) throw new TaskNotFoundException("Task with that ID does not exist");
            if (taskFromDb.Title != dto.Title)
            {
                taskFromDb.Title = dto.Title;
            }

            if (taskFromDb.Description != dto.Description)
            {
                taskFromDb.Description = dto.Description;
            }

            if (taskFromDb.DateDue != dto.DateDue)
            {
                taskFromDb.DateDue = dto.DateDue;
            }

            if (taskFromDb.Assignees.Count != dto.Assignees.Count)
            {
               await _taskAssigneesRepository.AssignUsersToTask(dto.Assignees, taskFromDb.Id);
            }

            if (taskFromDb.IsCompleted != dto.IsCompleted)
            {

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

        public async Task<TaskDTO> GetTaskWithAssigneesAsync(long id)
        {
            var task = await _taskRepository.GetTaskWithAssigneesAsync(id);
            return task.ToDto();
        }
    }
}

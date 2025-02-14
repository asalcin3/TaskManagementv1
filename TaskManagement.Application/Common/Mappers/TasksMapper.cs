
using TaskManagement.Application.Common.DTOs;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Common.Mappers
{
    public static class TasksMapper
    {
        public static TaskDTO ToDto(this  Task entity)
        {
            return new TaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                IsCompleted = entity.IsCompleted,
                Description = entity.Description,
                DateDue = entity.DateDue,
                Assignees = entity.Assignees?.Select(a => a.UserId).ToList() ?? new List<long>()

            };
        }

        public static Task ToEntity(this TaskDTO dto)
        {
            return new Task
            {
                Id = dto.Id,
                Title = dto.Title,
                DateDue = dto.DateDue,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
              
            };
        }

        public static Task MapCreateTask(this TaskDTO.CreateTaskDTO source)
        {
            return new Task
            {
                Title = source.Title,
                Description = source.Description,
                IsCompleted = source.IsCompleted,
            };
        }

    }
}

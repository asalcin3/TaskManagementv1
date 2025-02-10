
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
                Description = entity.Description


            };
        }

        public static Task ToEntity(this TaskDTO dto)
        {
            return new Task
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description
              
            };
        }

        public static Task MapCreateTask(this CreateTaskDTO source)
        {
            return new Task
            {
                Title = source.Title,
                Description = source.Description

            };
        }

    }
}

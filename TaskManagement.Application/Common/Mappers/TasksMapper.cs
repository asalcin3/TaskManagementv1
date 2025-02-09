
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
                Title = entity.Title
      
            };
        }

        public static Task ToEntity(this TaskDTO dto)
        {
            return new Task
            {
                Id = dto.Id,
                Title = dto.Title,
              
            };
        }

    }
}

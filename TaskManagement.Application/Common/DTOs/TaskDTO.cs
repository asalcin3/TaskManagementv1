namespace TaskManagement.Application.Common.DTOs
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class CreateTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

    }


}

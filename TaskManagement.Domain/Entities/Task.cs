using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateDue { get; set; }
        public bool IsCompleted { get; set; }
        public List<TaskAssignee> Assignees { get; set; }

    }
}

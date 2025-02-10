using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class TaskAssignee
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime DateTimeAssigned { get; set; }

        public DateTime? DateTimeFinished { get; set; }

        public string? FinishedBy { get; set; }


        // Navigation //
        [Required]
        public long TaskId{ get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        [Required]
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }

    }
}

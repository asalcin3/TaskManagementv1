using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Common.DTOs
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

    }

    public class CreateTaskDTO
    {
        public string Title { get; set; }
    }

}

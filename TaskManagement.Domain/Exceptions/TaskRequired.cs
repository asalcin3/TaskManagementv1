using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Exceptions
{
    public class TaskRequired: Exception
    {
        public TaskRequired(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Exceptions;
namespace TaskManagement.Domain.Exceptions
{
    public class TaskNotFoundException : NotFoundException
    {
        public TaskNotFoundException()
        {
        }
        public TaskNotFoundException(string message) : base(message) { }


    }
}

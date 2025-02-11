
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

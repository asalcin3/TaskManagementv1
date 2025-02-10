using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        //navigation
        public List<TaskAssignee> TaskAssignees { get; set; }
    }
}

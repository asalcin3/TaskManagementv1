using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        //navigation
        public List<TaskAssignee> TaskAssignees { get; set; }
        [InverseProperty("Sender")]
        public List<Message> MessageSender { get; set; }

        [InverseProperty("Receiver")]
        public List<Message> MessageReceiver { get; set; }
    }
}

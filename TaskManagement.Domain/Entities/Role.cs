using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Domain.Entities
{
    public class Role : IdentityRole<long>
    {
        public Role() { }
        public Role(string roleName) : base(roleName)
        {
        }
    }
}

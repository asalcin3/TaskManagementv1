
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Context
{
    // ReSharper disable once InconsistentNaming
    public class TMContext : IdentityDbContext
    <
        User,
        Role, 
        long, 
        IdentityUserClaim<long>,
        UserRole, 
        IdentityUserLogin<long>, 
        IdentityRoleClaim<long>,
        IdentityUserToken<long>
    >
    {
        public TMContext(DbContextOptions<TMContext> options)
            : base(options)
        {
           
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskAssignee> TaskAssignees { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<long>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<long>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<long>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<long>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}

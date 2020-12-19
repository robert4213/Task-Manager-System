using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class TaskManagerDbContext:DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskHistory>().Property(history => history.Completed).HasDefaultValueSql("getdate()");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        
        public DbSet<TaskHistory> TaskHistories { get; set; }
        
    }
}
using Microsoft.EntityFrameworkCore;

namespace Taskify_API.Models
{
    public class TaskifyDbContext : DbContext
    {
        public TaskifyDbContext(DbContextOptions<TaskifyDbContext> options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}

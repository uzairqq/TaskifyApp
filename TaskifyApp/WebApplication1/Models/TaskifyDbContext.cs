using Microsoft.EntityFrameworkCore;

namespace TaskifyAPI.Models
{
    public class TaskifyDbContext : DbContext
    {
        public TaskifyDbContext(DbContextOptions<TaskifyDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace TaskifyApp.Models
{
    public class TaskifyDbContext : DbContext
    {
        public TaskifyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

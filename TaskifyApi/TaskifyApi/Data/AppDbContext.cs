using Microsoft.EntityFrameworkCore;
using TaskifyApi.Models;

namespace TaskifyApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskifyAPI.Models;

namespace TaskifyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }

    }
}

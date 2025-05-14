using Microsoft.EntityFrameworkCore;
using SimpleTaskManagerAPI.Models;

namespace SimpleTaskManagerAPI.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
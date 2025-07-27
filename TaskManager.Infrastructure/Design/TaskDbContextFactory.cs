using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Design
{
    public class TaskDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
    {
        public TaskDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            return new TaskDbContext(optionsBuilder.Options);
        }
    }
}

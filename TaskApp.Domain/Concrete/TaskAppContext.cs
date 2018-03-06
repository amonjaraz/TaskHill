using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Concrete
{
    public class TaskAppContext : DbContext
    {
        public TaskAppContext() : base("name=TaskApp")
        {
            Database.SetInitializer(new TaskAppInitializer());
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}

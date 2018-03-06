using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Concrete
{
    public class TaskAppInitializer : DropCreateDatabaseAlways<TaskAppContext>
    {
        protected override void Seed(TaskAppContext context)
        {
            List<TaskItem> Tasks = new List<TaskItem>
            {
                new TaskItem {Description="Task 1" },
                new TaskItem {Description="Task 1A"},
                new TaskItem {Description="Task 1B" },
                new TaskItem {Description="Task 2" },
            };

            Tasks.ForEach(task => context.Tasks.Add(task));
            context.SaveChanges();
        }
    }
}

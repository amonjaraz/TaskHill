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
                new TaskItem {Description="Task 1", Level = 1, Subdivided = true, Time = 7, ParentId = null, CategoryId = 0 },
                new TaskItem {Description="Task 1A", Level = 2, Subdivided = false, Time = 3, ParentId = 1, CategoryId = 0 },
                new TaskItem {Description="Task 1B", Level = 3, Subdivided = false, Time = 4, ParentId = 2, CategoryId = 0 },
                new TaskItem {Description="Task 2", Level = 1, Subdivided = false, Time = 5, ParentId = null, CategoryId = 0 },
            };

            Tasks.ForEach(task => context.Tasks.Add(task));
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Abstract.Repos;
using System.Data.Entity;

namespace TaskApp.Domain.Concrete.Repos
{
    public class TaskRepo : Repo<TaskItem>, ITaskRepo
    {
        public TaskAppContext TaskAppContext { get { return Context as TaskAppContext; }  }

        public TaskRepo(TaskAppContext context) : base(context)
        {
        }

        public string GetTaskDesc(int id)
        {
            return TaskAppContext.Tasks.Find(id)?.Description ?? "";
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return TaskAppContext.Tasks.ToArray();
        }

        public void UpdateParentTasks(TaskItem item, bool increase)
        {
            

            TaskItem parentItem;
            if (item.ParentId != null)
            {
                parentItem = this.Get((int)item.ParentId);
                if (increase) parentItem.Time += item.Time;
                else parentItem.Time -= item.Time;

                UpdateParentTasks(parentItem, increase);
            } 
        }
    }
}

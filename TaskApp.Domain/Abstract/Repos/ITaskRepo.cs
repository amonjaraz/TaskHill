using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Abstract.Repos
{
    public interface ITaskRepo : IRepo<TaskItem>
    {
        //Todo Add more useful methods here for Task items.
        string GetTaskDesc(int id);
        IEnumerable<TaskItem> GetAllTasks();
    }
}

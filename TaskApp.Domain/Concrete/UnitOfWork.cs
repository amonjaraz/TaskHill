using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskApp.Domain.Abstract;
using TaskApp.Domain.Abstract.Repos;
using TaskApp.Domain.Concrete.Repos;

namespace TaskApp.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskAppContext _context;
        public ITaskRepo Tasks { get; private set; }

        public UnitOfWork(TaskAppContext context)
        {
            _context = context;
            Tasks = new TaskRepo(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

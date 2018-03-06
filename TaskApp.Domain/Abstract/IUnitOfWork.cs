using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Abstract.Repos;


namespace TaskApp.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepo Tasks { get; } // Remove set to make read-only
        void Complete();
    }
}

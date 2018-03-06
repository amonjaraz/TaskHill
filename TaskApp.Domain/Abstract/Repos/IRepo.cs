using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;

namespace TaskApp.Domain.Abstract.Repos
{
    public interface IRepo<TEntity> where TEntity: class
    {
        void Add(TEntity item);
        TEntity Get(int Id);
        void Remove(TEntity item);
    }
}

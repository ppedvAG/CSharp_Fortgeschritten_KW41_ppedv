using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public abstract class GenericRepositoryBase<TEntity, TEntityKey> : IRepository<TEntity, TEntityKey> where TEntity : class
    {
        public abstract void Delete(TEntity item);

        public abstract IList<TEntity> GetAll();

        public abstract TEntity GetById(TEntityKey key);

        public abstract void Insert(TEntity item);

        public abstract void Update(TEntity item);
    }
}

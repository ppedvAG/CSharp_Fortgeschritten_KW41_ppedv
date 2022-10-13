using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EF
{

    
    public class EFRepositoryBase<T, TKey> : GenericRepositoryBase<T, TKey> where T : class
    {
        //DbContext und DbSet sind auf dem EFCore-Package
        //DbContext stellt die Verbindung mit Scope auf die DB
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;



        public EFRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public override void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public override IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public override T GetById(TKey key)
        {
            T result;

            if (key is int integerKey)
            {
                result = _dbSet.Find(integerKey);
            }
            else if (key is Guid guidId)
            {
                result = _dbSet.Find(guidId);
            }
            else
                throw new Exception("Key ist not supported");

            return result;
        }

        public override void Insert(T item)
        {
            _dbSet.Add(item);
        }

        public override void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IRepository<T, TKey> : IReadonlyRepository<T, TKey> where T : class
    {
        void Insert(T item);
        void Update(T item);

        void Delete(T item);
    }
}

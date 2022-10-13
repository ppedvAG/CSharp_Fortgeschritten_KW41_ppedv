using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IReadonlyRepository<T, TKey> where T : class
    {
        IList<T> GetAll();
        T GetById(TKey key);
    }
}

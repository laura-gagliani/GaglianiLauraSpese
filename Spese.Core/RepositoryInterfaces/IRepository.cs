using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.Core.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll(Func<T, bool> filter = null);
        T Update(T entity);
        T Delete(T entity);
        T Add(T entity);
    }
}

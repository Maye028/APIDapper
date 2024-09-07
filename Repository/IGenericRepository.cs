using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDapper.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetbyId(int id);

        bool Add(T entity);

        bool Update(T entity);

        bool Delete(int id);
        string GetColumnValues(bool excludeKey = false);
    }
}
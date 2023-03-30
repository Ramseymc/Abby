using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {        
        // Add 
        void Add(T entity);

        // Remove
        void Remove(T entity);

        // Remove Range 
        void RemoveRange(IEnumerable<T> entity);

        // GET ALL
        IEnumerable<T> GetAll(string includeProperties = null);

        // GetByID First or Default 
        T GetFirstOrDefault(Expression<Func<T,bool>>? filter = null);
    }
}

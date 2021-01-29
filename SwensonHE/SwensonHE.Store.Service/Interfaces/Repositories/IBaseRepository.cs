using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IBaseRepository<T> where T : class
    { 
        Task<T> FindById(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> FindAll();
        Task<IQueryable<T>> Where(Expression<Func<T, bool>> predicate);
    }
}

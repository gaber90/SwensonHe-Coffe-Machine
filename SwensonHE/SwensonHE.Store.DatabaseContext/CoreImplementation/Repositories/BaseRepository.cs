using SwensonHE.Store.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwensonHE.Store.Presistance.CoreImplementation.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IStoreDBEntities _context;
        public BaseRepository(IStoreDBEntities context)
        {
            _context = context;
        }
        private IStoreDBEntities StoreDBEntities => _context;

        public async Task<IQueryable<T>> FindAll()
        {
            return StoreDBEntities.Set<T>();
        }

        public async Task<T> FindById(Expression<Func<T, bool>> predicate)
        {
            return StoreDBEntities.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<IQueryable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return StoreDBEntities.Set<T>().Where(predicate).AsQueryable();
        }
    }

}

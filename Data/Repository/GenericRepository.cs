using System.Collections.Generic;
using CMS.Systems.StockManagement.Entities.BaseEntities;
using CMS.Systems.StockManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Systems.StockManagement.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : SoftDeleteBase
    {
        #region Fields
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _dbContext;
        #endregion 

        public GenericRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        
        public IAsyncEnumerable<T> GetAllAsync(bool shouldTrackChanges = true)
        {
            if (shouldTrackChanges)
            {
                //tracks changes.
                return _dbSet.AsAsyncEnumerable();
            }

            //tracks no changes.
            return _dbSet.AsNoTracking().AsAsyncEnumerable();
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}

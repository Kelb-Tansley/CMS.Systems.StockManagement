using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMS.Systems.StockManagement.Entities.BaseEntities;
using CMS.Systems.StockManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Systems.StockManagement.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : SoftDeleteBase
    {
        #region Fields
        private protected readonly DbSet<T> _dbSet;
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

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(bool shouldTrackChanges = true)
        {
            if (shouldTrackChanges)
            {
                //tracks changes.
                return await _dbSet.ToListAsync();
            }

            //tracks no changes.
            return await _dbSet.AsNoTracking().ToListAsync();
        }
    }
}

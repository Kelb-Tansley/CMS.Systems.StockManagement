using System.Collections.Generic;

namespace CMS.Systems.StockManagement.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        IAsyncEnumerable<T> GetAllAsync(bool shouldTrackChanges = true);
        int SaveChanges();
    }
}

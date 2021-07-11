using CMS.Systems.StockManagement.Entities.StockRoot;

namespace CMS.Systems.StockManagement.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<VehicleStock> VehicleStockRepository { get; }
        void Dispose();
        void Save();
    }
}

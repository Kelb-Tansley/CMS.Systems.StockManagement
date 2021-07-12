using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.Systems.StockManagement.Entities.StockRoot;

namespace CMS.Systems.StockManagement.Interfaces
{
    public interface IVehicleStockService
    {
        IEnumerable<VehicleStock> GetAllVehiclesAsync();
        Task<IList<VehicleStock>> GetAllVehiclesByUserNameAsync(string userName);
    }
}

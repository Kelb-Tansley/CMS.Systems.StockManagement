using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.Systems.StockManagement.Entities.StockRoot;
using CMS.Systems.StockManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Systems.StockManagement.Services
{
    public class VehicleStockService : IVehicleStockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleStockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<VehicleStock> GetAllVehiclesAsync()
        {
            //var collection = await _unitOfWork.VehicleStockRepository.GetAllAsync();
            return VehicleStock.GetTestData();
        }

        public async Task<IList<VehicleStock>> GetAllVehiclesByUserNameAsync(string userName)
        {
            return await _unitOfWork.VehicleStockRepository.GetAsync(vsr=> !vsr.IsDeleted && EF.Functions.Like(userName,vsr.CreatedBy));
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CMS.Systems.StockManagement.Entities.StockRoot;
using CMS.Systems.StockManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Systems.StockManagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VehicleStockController : ControllerBase
    {
        private readonly ILogger<VehicleStockController> _logger;
        private readonly IVehicleStockService _vehicleStockService;

        public VehicleStockController(ILogger<VehicleStockController> logger, IVehicleStockService vehicleStockService)
        {
            _logger = logger;
            _vehicleStockService = vehicleStockService;
        }

        [HttpGet]
        public IEnumerable<VehicleStock> Get()
        {
            return _vehicleStockService.GetAllVehiclesAsync();
        }
        //[HttpPost]
        //public async Task<IEnumerable<VehicleStock>> Post()
        //{
        //    return await _vehicleStockService.GetAllVehiclesAsync();
        //}
    }
}

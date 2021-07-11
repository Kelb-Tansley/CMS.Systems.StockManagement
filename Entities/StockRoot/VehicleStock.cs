using System;
using System.Collections.Generic;
using CMS.Systems.StockManagement.Entities.BaseEntities;

namespace CMS.Systems.StockManagement.Entities.StockRoot
{
    public class VehicleStock : EntityBase
    {
        //Compulsoy fields
        public string RegistrationNumber { get; set; }
        public string VinNumber { get; set; }
        public string Manufacturer { get; set; }
        public string ModelDescription { get; set; }
        public DateTime? ModelYear { get; set; }
        public double CurrentKilometreReading { get; set; }
        public string Colour { get; set; }
        public double RetailPrice { get; set; }
        public double CostPrice { get; set; }
        public IList<VehicleStockAccessory> Accessories { get; set; }
        public IList<VehicleStockImage> Images { get; set; }
        
    }
}

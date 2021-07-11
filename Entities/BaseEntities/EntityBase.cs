using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Systems.StockManagement.Entities.BaseEntities
{
    public class EntityBase : SoftDeleteBase
    {
        [Key]
        public new int Id { get; set; }
    }
}

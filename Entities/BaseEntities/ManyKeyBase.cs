using System.ComponentModel.DataAnnotations;

namespace CMS.Systems.StockManagement.Entities.BaseEntities
{
    public class ManyKeyBase : SoftDeleteBase
    {
        public new int Id { get; set; }
    }
}

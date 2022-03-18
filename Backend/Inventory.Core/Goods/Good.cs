using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Goods
{
    [Table("Goods")]
    public class Good : IEntityBase
    {
        [Column("GoodID")]
        public Guid Id { get; set; }
        public string GoodName { get; set; }
        public string? CreatedBy { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }
        public string? ModifiedBy { get ; set; }
        public DateTime? ModifiedDate { get ; set ; }
        
    }
}

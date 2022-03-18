using Inventory.Core.Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Stocks
{
    [Table("Stock")]
    public class Stock:IEntityBase
    {
        [Column("StockId")]
        public Guid Id { get; set; }
        public virtual Guid GoodID { get; set; }
        public Good Good { get; set; }
        public double Quantity { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

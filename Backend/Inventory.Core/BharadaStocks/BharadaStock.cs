using Inventory.Core.RateTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.BharadaStocks
{
    public class BharadaStock
    {
        [Column("BharadaStockId")]
        public virtual Guid? BharadaRateID { get; set; }
        public BharadaRate BharadaRate { get; set; }
        public double? Quantity { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

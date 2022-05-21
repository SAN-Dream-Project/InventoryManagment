using Inventory.Core.Goods;
using Inventory.Core.GoodSuppliers;
using Inventory.Core.Kadatas;
using Inventory.Core.LabourRates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Purchases
{
    [Table("Purchase")]
    public class Purchase:IEntityBase
    {
        [Column("PurchaseId")]
        public Guid Id { get; set; }
        public virtual Guid GoodID { get; set; }
        public Good Good { get; set; }
        public virtual Guid GoodSupplierID { get; set; }
        public GoodSupplier GoodSupplier { get; set; }
        public double? GrossGoodQuantity { get; set; }
        public double? GoodRate { get; set; }
        public virtual Guid? KadataID { get; set; }
        public Kadata Kadata { get; set; }
        public int? KadtaTotal { get; set; }
        public double? NetGoodQuantity { get; set; }
        public virtual Guid? LabourRateID { get; set; }
        public LabourRate LabourRate { get; set; }
        public double? TotalLabourCosting { get; set; }
        public double? TotalAmount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}

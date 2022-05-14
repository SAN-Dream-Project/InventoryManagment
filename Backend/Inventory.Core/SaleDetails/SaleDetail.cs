using Inventory.Core.Goods;
using Inventory.Core.LabourRates;
using Inventory.Core.Retailers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.SaleDetails
{
    [Table("SaleDetail")]
    public class SaleDetail:IEntityBase
    {
        [Column("SaleDetailID")]
        public Guid Id { get; set; }
        public virtual Guid GoodID { get; set; }
        public Good Good { get; set; }
        public virtual Guid RetailerID { get; set; }
        public Retailer GoodSupplier { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public virtual Guid? LabourRateID { get; set; }
        public LabourRate LabourRate { get; set; }
        public double? TotalLabourCosting { get; set; }
        public double? Discount { get; set; }
        public double? TotalAmount { get; set; }
        public string? VehicleNumber { get; set; }
        public string? DriverName { get; set; }
        public double? TransportCharges { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

using Inventory.Core.LabourRates;
using Inventory.Core.RateTables;
using Inventory.Core.Retailers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.BharadaSaleDetails
{
    [Table("BharadaSaleDetail")]
    public class BharadaSaleDetail:IEntityBase
    {
        [Column("BharadaSaleDetailID")]
        public Guid Id { get; set; }
        public virtual Guid? BharadaRateID { get; set; }
        public  BharadaRate BharadaRate { get; set; }
        public double? Quntity { get; set; }
        public virtual Guid? RetailerID { get; set; }
        public  Retailer Retailer { get; set; }
        public double? ToatalAmount { get; set; }
        public double? Discount { get; set; }
        public virtual Guid? LabourRateID { get; set; }
        public  LabourRate LabourRate { get; set; }
        public double? TotalLabourCosting { get; set; }
        public double? NetAmount { get; set; }
        public double? PaidAmount { get; set; }
        public double? RemainingAmount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

using Inventory.Core.BharadaSaleDetails;
using Inventory.Core.Retailers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.BharadaCreditDetails
{
    [Table("BharadaCreditDetail")]
    public class BharadaCreditDetail:IEntityBase
    {
        [Column("BharadaCreditDetailID")]
        public Guid Id { get; set; }
        public Guid? RetailerID { get; set; }
        public Retailer Retailer { get; set; }
        public Guid? BharataSaleDetailID { get; set; }
        public BharadaSaleDetail BharataSaleDetail { get; set; }
        public double? PaidAmout { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}

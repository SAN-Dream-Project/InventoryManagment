using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.SaleDetails.Dto
{
    public class SaleDetailInputDto
    {
        public Guid Id { get; set; }
        public virtual Guid GoodID { get; set; }
        public virtual Guid RetailerID { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public virtual Guid? LabourRateID { get; set; }
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

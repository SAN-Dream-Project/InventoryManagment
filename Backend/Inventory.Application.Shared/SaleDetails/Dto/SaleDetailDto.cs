using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.SaleDetails.Dto
{
    public class SaleDetailDto
    {
        public Guid Id { get; set; }
        public string? GoodName { get; set; }
        public string? GoodRetailerName { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public double LabourRate { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Purchases.Dto
{
    public class PurchaseInputDto
    {
        public Guid Id { get; set; }
        public  Guid GoodID { get; set; }
        public  Guid GoodSupplierID { get; set; }
        public double? GrossGoodQuantity { get; set; }
        public double? GoodRate { get; set; }
        public  Guid? KadataID { get; set; }
        public int? KadtaTotal { get; set; }
        public double? NetGoodQuantity { get; set; }
        public  Guid? LabourRateID { get; set; }
        public double? TotalLabourCosting { get; set; }
        public double? TotalAmount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

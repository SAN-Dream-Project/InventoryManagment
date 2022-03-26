using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.BharadaCreditDetails.Dto
{
    public class BharadaCreditDetailInputDto
    {
        public Guid Id { get; set; }
        public Guid? RetailerID { get; set; }
        public Guid? BharataSaleDetailID { get; set; }
        public double? PaidAmout { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

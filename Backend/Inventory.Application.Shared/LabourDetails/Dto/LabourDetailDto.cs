using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.LabourDetails.Dto
{
    public class LabourDetailDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Boolean IsPaid { get; set; }
        public virtual Guid LabourID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

using Inventory.Core.Labours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.LabourDetails
{
    [Table("LabourDetail")]
    public class LabourDetail : IEntityBase
    {
        [Column("LabourDetailID")]
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Boolean IsPaid { get; set; }
        public virtual Guid LabourID { get; set; }
        public Labour Labour { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

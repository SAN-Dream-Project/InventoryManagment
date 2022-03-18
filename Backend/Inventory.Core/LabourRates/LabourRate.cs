using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.LabourRates
{
    [Table("LabourRate")]
    public class LabourRate:IEntityBase
    {
        [Column("LabourRateID")]
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

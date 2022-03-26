using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Kadatas
{
    [Table("Kadatas")]
    public class Kadata:IEntityBase
    {
        [Column("KadataID")]
        public Guid Id { get; set; }
        public int? KadtaQuantity { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
     
    }
}

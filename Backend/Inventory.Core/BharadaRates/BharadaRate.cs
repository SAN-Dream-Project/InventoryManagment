using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.RateTables
{
    [Table("BharadaRate")]
    public class BharadaRate:IEntityBase
    {
        [Column("BharadaRateID")]
        public Guid Id { get; set; }
        public int? RateCriteriaID { get; set; }
        public string? RateCriteria { get; set; }
        public double Rate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

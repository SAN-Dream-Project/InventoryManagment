using Inventory.Core.Shared.EmplyeeTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.SalaryDetails
{
    [Table("SalaryDetail")]
    public class SalaryDetail:IEntityBase
    {
        [Column("SalaryDetailID")]
        public Guid Id { get; set; }
        public double? MonthlySalary { get; set; }
        public EmplyeeType? EmplyeeType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double WorkingDays { get; set; }
        public double PaidAmount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

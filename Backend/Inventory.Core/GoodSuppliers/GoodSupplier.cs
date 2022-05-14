using Inventory.Core.Shared.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.GoodSuppliers
{
    [Table("GoodSuppliers")]
    public class GoodSupplier:IEntityBase
    {
        [Column("GoodSupplierID")]
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public Gender? Gender { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? Address { get; set; }
        public string? BankAccountNo { get; set; }
        public string? IFSC { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Users.Roles
{
    [Table("Roles")]
    public class Role : IEntityBase
    {
        [Column("RoleId")]
        public Guid Id { get ; set ; }
        public string RoleName { get; set; }
        public string? CreatedBy { get ; set; }
        public DateTime? CreatedDate { get ; set; }
        public string? ModifiedBy { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public string? DeletedBy { get ; set ; }
        public DateTime? DeleteDate { get ; set ; }
    }
}

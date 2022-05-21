using Inventory.Core.Shared.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.UserAndRoles.Users
{
    [Table("Users")]
    public class User : IEntityBase
    {
        [Column("UserId")]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean? Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryMobNo { get; set; }
        public string SecondaryMobNo { get; set; }
        public string TelephoneNo { get; set; }
        public Gender? Gender { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}

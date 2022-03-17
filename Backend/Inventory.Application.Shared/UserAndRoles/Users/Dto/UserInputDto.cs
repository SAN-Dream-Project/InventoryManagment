using Inventory.Core.Shared.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.UserAndRoles.Users.Dto
{
    public  class UserInputDto
    {
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
    }
}

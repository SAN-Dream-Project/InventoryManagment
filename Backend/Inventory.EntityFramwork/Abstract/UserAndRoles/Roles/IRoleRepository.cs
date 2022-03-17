using Inventory.Core.Users.Roles;
using Inventory.EntityFramwork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Abstract.UserAndRoles.Roles
{
    public interface IRoleRepository : IEntityBaseRepository<Role> { }
}

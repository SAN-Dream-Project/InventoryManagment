using Inventory.Core.Users.Roles;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.UserAndRoles.Roles
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(InventoryContext context)
            : base(context)
        { }
    }
}

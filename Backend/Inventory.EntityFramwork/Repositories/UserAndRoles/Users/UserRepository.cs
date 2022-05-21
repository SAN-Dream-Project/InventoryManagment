using Inventory.Core.UserAndRoles.Users;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.UserAndRoles.Users
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(InventoryContext context)
            : base(context)
        { }
    }
}

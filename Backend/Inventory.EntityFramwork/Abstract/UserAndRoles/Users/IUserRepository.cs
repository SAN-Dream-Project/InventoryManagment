using Inventory.Core.UserAndRoles.Users;
using Inventory.EntityFramwork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Abstract.UserAndRoles.Users
{
    public interface IUserRepository : IEntityBaseRepository<User> { }
    
}

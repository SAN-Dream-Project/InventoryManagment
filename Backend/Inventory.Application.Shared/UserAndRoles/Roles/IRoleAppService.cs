using Inventory.Application.Shared.UserAndRoles.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.UserAndRoles.Roles
{
    public interface IRoleAppService
    {
        Task CreateOrUpdateRole(RoleInputDto roleInputDto);
        Task DeleteRole(Guid roleId);
        Task<RoleDto> GetRole(Guid roleId);
        Task<List<RoleDto>> GetAllRoles();
    }
}

using AutoMapper;
using Inventory.Application.Shared.UserAndRoles.Roles;
using Inventory.Application.Shared.UserAndRoles.Roles.Dto;
using Inventory.Core.Users.Roles;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.UserAndRoles.Roles
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleAppService(IRoleRepository roleRepository)
        {
            _RoleRepository = roleRepository;
        }

        public async Task CreateOrUpdateRole(RoleInputDto roleInputDto)
        {
            if (roleInputDto.Id == null || roleInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<RoleInputDto, Role>(roleInputDto);
                await _RoleRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<RoleInputDto, Role>(roleInputDto);
                await _RoleRepository.Update(result);
            }
        }

        public async Task DeleteRole(Guid roleId)
        {
            var result = await _RoleRepository.GetSingle(roleId);
            await _RoleRepository.Delete(result);
        }

        public async Task<List<RoleDto>> GetAllRoles()
        {
            var result = await _RoleRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<RoleDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Role, RoleDto>(test));
            }
            return roleList;
        }

        public async Task<RoleDto> GetRole(Guid roleId)
        {
            var result = await _RoleRepository.GetSingle(roleId);
            var returnResult = Mapper.Map<Role, RoleDto>(result);
            return returnResult;
        }

       
    }
}

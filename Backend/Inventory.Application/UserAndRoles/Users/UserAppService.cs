using AutoMapper;
using Inventory.Application.Shared.UserAndRoles.Users;
using Inventory.Application.Shared.UserAndRoles.Users.Dto;
using Inventory.Core.UserAndRoles.Users;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.UserAndRoles.Users
{

    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateOrUpdateUser(UserInputDto userInputDto)
        {
            if (userInputDto.Id == null || userInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<UserInputDto, User>(userInputDto);
                await _userRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<UserInputDto, User>(userInputDto);
                await _userRepository.Update(result);
            }
        }

        public async Task DeleteRole(Guid userId)
        {
            var result = await _userRepository.GetSingle(userId);
            await _userRepository.Delete(result);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<UserDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<User, UserDto>(test));
            }
            return roleList;
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var result = await _userRepository.GetSingle(userId);
            var returnResult = Mapper.Map<User, UserDto>(result);
            return returnResult;
        }
    }
}

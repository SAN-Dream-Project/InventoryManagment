using AutoMapper;
using Inventory.Application.Shared.UserAndRoles.Roles.Dto;
using Inventory.Application.Shared.UserAndRoles.Users.Dto;
using Inventory.Core.UserAndRoles.Users;
using Inventory.Core.Users.Roles;

namespace Inventory.Application
{
   public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleInputDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserInputDto>().ReverseMap();
        }
    }
}

using Inventory.Application.Shared.UserAndRoles.Roles;
using Inventory.Application.Shared.UserAndRoles.Roles.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly ILogger<UserRoleController> _logger;
        public UserRoleController(IRoleAppService roleAppService, ILogger<UserRoleController> logger)
        {
            _roleAppService = roleAppService;
            _logger = logger;
        }
        //Add Role  
        [HttpPost("AddRole")]
        public async Task AddRole([FromBody] RoleInputDto input)
        {
            try
            {
                await _roleAppService.CreateOrUpdateRole(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete Role  
        [HttpDelete("DeleteRole")]
        public async Task DeleteRole(Guid id)
        {
            try
            {
                await _roleAppService.DeleteRole(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All Role by Name  
        [HttpGet("GetAllRole")]
        public async Task<List<RoleDto>> GetAllRoles()
        {
            try
            {
                return await _roleAppService.GetAllRoles();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<RoleDto>();
            }
        }
        //GET All Role by Name  
        [HttpGet("GetById")]
        public async Task<RoleDto> GetRole(Guid id)
        {
            try
            {
                return await _roleAppService.GetRole(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return null;
            }
        }
    }
}

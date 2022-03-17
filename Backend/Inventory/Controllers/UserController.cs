using Inventory.Application.Shared.UserAndRoles.Users;
using Inventory.Application.Shared.UserAndRoles.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserAppService userAppService, ILogger<UserController> logger)
        {
            _userAppService = userAppService;
            _logger = logger;
        } //Add Role  
        [AllowAnonymous]
        [HttpPost("AddUser")]
        public async Task AddUser([FromBody] UserInputDto input)
        {
            try
            {
                await _userAppService.CreateOrUpdateUser(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(Guid id)
        {
            try
            {
                await _userAppService.DeleteRole(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllUser")]
        public async Task<List<UserDto>> GetAllUsers()
        {
            try
            {
                return await _userAppService.GetAllUsers();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<UserDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<UserDto> GetUser(Guid id)
        {
            try
            {
                return await _userAppService.GetUser(id);
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

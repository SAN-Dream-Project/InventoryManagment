using Inventory.Application.Shared.EmployeeDetails;
using Inventory.Application.Shared.EmployeeDetails.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly IEmployeeDetailAppService _employeeDetailAppService;
        private readonly ILogger<UserController> _logger;

        public EmployeeDetailController(IEmployeeDetailAppService goodAppService, ILogger<UserController> logger)
        {
            _employeeDetailAppService = goodAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddEmployeeDetail")]
        public async Task AddEmployeeDetail([FromBody] EmployeeDetailInputDto input)
        {
            try
            {
                await _employeeDetailAppService.CreateOrUpdateEmployeeDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteEmployeeDetail")]
        public async Task DeleteEmployeeDetail(Guid id)
        {
            try
            {
                await _employeeDetailAppService.DeleteEmployeeDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllEmployeeDetail")]
        public async Task<List<EmployeeDetailDto>> GetAllEmployeeDetail()
        {
            try
            {
                return await _employeeDetailAppService.GetAllEmployeeDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<EmployeeDetailDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<EmployeeDetailDto> GetEmployeeDetail(Guid id)
        {
            try
            {
                return await _employeeDetailAppService.GetEmployeeDetail(id);
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

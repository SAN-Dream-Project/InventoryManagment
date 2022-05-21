using Inventory.Application.Shared.SalaryDetails;
using Inventory.Application.Shared.SalaryDetails.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalaryDetailController : ControllerBase
    {
        private readonly ISalaryDetailAppService _salaryDetailAppService;
        private readonly ILogger<UserController> _logger;

        public SalaryDetailController(ISalaryDetailAppService salaryDetailAppService, ILogger<UserController> logger)
        {
            _salaryDetailAppService = salaryDetailAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddSalaryDetail")]
        public async Task AddSalaryDetail([FromBody] SalaryDetailInputDto input)
        {
            try
            {
                await _salaryDetailAppService.CreateOrUpdateSalaryDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteSalaryDetail")]
        public async Task DeleteSalaryDetail(Guid id)
        {
            try
            {
                await _salaryDetailAppService.DeleteSalaryDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllSalaryDetail")]
        public async Task<List<SalaryDetailDto>> GetAllSalaryDetails()
        {
            try
            {
                return await _salaryDetailAppService.GetAllSalaryDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<SalaryDetailDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<SalaryDetailDto> GetSalaryDetail(Guid id)
        {
            try
            {
                return await _salaryDetailAppService.GetSalaryDetail(id);
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

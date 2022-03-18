using Inventory.Application.Shared.LabourRates;
using Inventory.Application.Shared.LabourRates.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LabourRateController : ControllerBase
    {
        private readonly ILabourRateAppService _labourRateAppService;
        private readonly ILogger<UserController> _logger;

        public LabourRateController(ILabourRateAppService labourRateAppService, ILogger<UserController> logger)
        {
            _labourRateAppService = labourRateAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddLabourRate")]
        public async Task AddLabourRate([FromBody] LabourRateInputDto input)
        {
            try
            {
                await _labourRateAppService.CreateOrUpdateLabourRate(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteLabourRate")]
        public async Task DeleteLabourRate(Guid id)
        {
            try
            {
                await _labourRateAppService.DeleteLabourRate(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllLabourRates")]
        public async Task<List<LabourRateDto>> GetAllGoods()
        {
            try
            {
                return await _labourRateAppService.GetAllLabourRates();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<LabourRateDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<LabourRateDto> GetLabourRate(Guid id)
        {
            try
            {
                return await _labourRateAppService.GetLabourRate(id);
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

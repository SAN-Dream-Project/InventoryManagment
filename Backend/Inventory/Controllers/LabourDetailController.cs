using Inventory.Application.Shared.LabourDetails;
using Inventory.Application.Shared.LabourDetails.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LabourDetailController : ControllerBase
    {
        private readonly ILabourDetailAppService _labourDetailAppService;
        private readonly ILogger<UserController> _logger;

        public LabourDetailController(ILabourDetailAppService labourDetailAppService, ILogger<UserController> logger)
        {
            _labourDetailAppService = labourDetailAppService;
            _logger = logger;
        } 
        [HttpPost("AddLabourDetail")]
        public async Task AddLabourDetail([FromBody] LabourDetailInputDto input)
        {
            try
            {
                await _labourDetailAppService.CreateOrUpdateLabourDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
       
        [HttpDelete("DeleteLabourDetail")]
        public async Task DeleteLabourDetail(Guid id)
        {
            try
            {
                await _labourDetailAppService.DeleteLabourDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
       
        [HttpGet("GetAllLabourDetails")]
        public async Task<List<LabourDetailDto>> GetAllGoods()
        {
            try
            {
                return await _labourDetailAppService.GetAllLabourDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<LabourDetailDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<LabourDetailDto> GetLabourDetail(Guid id)
        {
            try
            {
                return await _labourDetailAppService.GetLabourDetail(id);
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

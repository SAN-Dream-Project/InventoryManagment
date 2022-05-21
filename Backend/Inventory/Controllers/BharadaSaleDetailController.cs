using Inventory.Application.Shared.BharadaSaleDetails;
using Inventory.Application.Shared.BharadaSaleDetails.Dto;
using Inventory.Application.Shared.Dropdowns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
  
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BharadaSaleDetailController : ControllerBase
    {
        private readonly IBharadaSaleDetailAppService _bharadaSaleDetaildAppService;
        private readonly ILogger<UserController> _logger;

        public BharadaSaleDetailController(IBharadaSaleDetailAppService bharadaSaleDetaildAppService, ILogger<UserController> logger)
        {
            _bharadaSaleDetaildAppService = bharadaSaleDetaildAppService;
            _logger = logger;
        } 
        [HttpPost("AddBharadaSaleDetail")]
        public async Task AddBharadaSaleDetail([FromBody] BharadaSaleDetailInputDto input)
        {
            try
            {
                await _bharadaSaleDetaildAppService.CreateOrUpdateBharadaSaleDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteBharadaSaleDetail")]
        public async Task DeleteBharadaSaleDetail(Guid id)
        {
            try
            {
                await _bharadaSaleDetaildAppService.DeleteBharadaSaleDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        
        [HttpGet("GetAllBharadaSaleDetail")]
        public async Task<List<BharadaSaleDetailDto>> GetAllBharadaSaleDetails()
        {
            try
            {
                return await _bharadaSaleDetaildAppService.GetAllBharadaSaleDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<BharadaSaleDetailDto>();
            }
        }
       
        [HttpGet("GetById")]
        public async Task<BharadaSaleDetailDto> GetBharadaSaleDetail(Guid id)
        {
            try
            {
                return await _bharadaSaleDetaildAppService.GetBharadaSaleDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return null;
            }
        }
        [HttpGet("GetBharadaSaleDetailList")]
        public async Task<List<Dropdown>> GetBharadaSaleDetailList()
        {
            try
            {
                return await _bharadaSaleDetaildAppService.GetBharadaSaleDetailList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<Dropdown>();
            }
        }
    }
}

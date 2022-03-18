using Inventory.Application.Shared.Retailers;
using Inventory.Application.Shared.Retailers.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RetailerController : ControllerBase
    {
        private readonly IRetailerAppService _retailerAppService;
        private readonly ILogger<UserController> _logger;

        public RetailerController(IRetailerAppService retailerAppService, ILogger<UserController> logger)
        {
            _retailerAppService = retailerAppService;
            _logger = logger;
        }   
        [HttpPost("AddRetailer")]
        public async Task AddRetailer([FromBody] RetailerInputDto input)
        {
            try
            {
                await _retailerAppService.CreateOrUpdateRetailer(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteRetailer")]
        public async Task DeleteRetailer(Guid id)
        {
            try
            {
                await _retailerAppService.DeleteRetailer(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllRetailer")]
        public async Task<List<RetailerDto>> GetAllRetailers()
        {
            try
            {
                return await _retailerAppService.GetAllRetailers();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<RetailerDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<RetailerDto> GetRetailer(Guid id)
        {
            try
            {
                return await _retailerAppService.GetRetailer(id);
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

using Inventory.Application.Shared.BharadaCreditDetails;
using Inventory.Application.Shared.BharadaCreditDetails.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BharadaCreditDetailController : ControllerBase
    {
        private readonly IBharadaCreditDetailAppService _bharadaCreditDetaildAppService;
        private readonly ILogger<UserController> _logger;

        public BharadaCreditDetailController(IBharadaCreditDetailAppService bharadaCreditDetaildAppService, ILogger<UserController> logger)
        {
            _bharadaCreditDetaildAppService = bharadaCreditDetaildAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddBharadaCreditDetail")]
        public async Task AddBharadaCreditDetail([FromBody] BharadaCreditDetailInputDto input)
        {
            try
            {
                await _bharadaCreditDetaildAppService.CreateOrUpdateBharadaCreditDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteBharadaCreditDetail")]
        public async Task DeleteBharadaCreditDetail(Guid id)
        {
            try
            {
                await _bharadaCreditDetaildAppService.DeleteBharadaCreditDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllBharadaCreditDetail")]
        public async Task<List<BharadaCreditDetailDto>> GetAllBharadaCreditDetails()
        {
            try
            {
                return await _bharadaCreditDetaildAppService.GetAllBharadaCreditDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<BharadaCreditDetailDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<BharadaCreditDetailDto> GetBharadaCreditDetail(Guid id)
        {
            try
            {
                return await _bharadaCreditDetaildAppService.GetBharadaCreditDetail(id);
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

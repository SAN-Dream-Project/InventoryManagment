using Inventory.Application.Shared.Kadatas;
using Inventory.Application.Shared.Kadatas.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KadataController : ControllerBase
    {
        private readonly IKadataAppService _kadataAppService;
        private readonly ILogger<UserController> _logger;

        public KadataController(IKadataAppService kadataAppService, ILogger<UserController> logger)
        {
            _kadataAppService = kadataAppService;
            _logger = logger;
        }   
        [HttpPost("AddKadata")]
        public async Task AddKadata([FromBody] KadataInputDto input)
        {
            try
            {
                await _kadataAppService.CreateOrUpdateKadata(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        } 
        [HttpDelete("DeleteKadata")]
        public async Task DeleteKadata(Guid id)
        {
            try
            {
                await _kadataAppService.DeleteKadata(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }  
        [HttpGet("GetAllKadata")]
        public async Task<List<KadataDto>> GetAllKadatas()
        {
            try
            {
                return await _kadataAppService.GetAllKadatas();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<KadataDto>();
            }
        }
       
        [HttpGet("GetById")]
        public async Task<KadataDto> GetKadata(Guid id)
        {
            try
            {
                return await _kadataAppService.GetKadata(id);
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

using Inventory.Application.Shared.Labours;
using Inventory.Application.Shared.Labours.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LabourController : ControllerBase
    {
        private readonly ILabourAppService _labourAppService;
        private readonly ILogger<UserController> _logger;

        public LabourController(ILabourAppService labourAppService, ILogger<UserController> logger)
        {
            _labourAppService = labourAppService;
            _logger = logger;
        }   
        [HttpPost("AddLabour")]
        public async Task AddLabour([FromBody] LabourInputDto input)
        {
            try
            {
                await _labourAppService.CreateOrUpdateLabour(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        [HttpDelete("DeleteLabour")]
        public async Task DeleteLabour(Guid id)
        {
            try
            {
                await _labourAppService.DeleteLabour(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllLabours")]
        public async Task<List<LabourDto>> GetAllLabours()
        {
            try
            {
                return await _labourAppService.GetAllLabours();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<LabourDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<LabourDto> GetLabour(Guid id)
        {
            try
            {
                return await _labourAppService.GetLabour(id);
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

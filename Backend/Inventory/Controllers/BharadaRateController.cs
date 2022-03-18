using Inventory.Application.Shared.BharadaRates;
using Inventory.Application.Shared.BharadaRates.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BharadaRateController : ControllerBase
    {
        private readonly IBharadaRateAppService _bharadaRatedAppService;
        private readonly ILogger<UserController> _logger;

        public BharadaRateController(IBharadaRateAppService bharadaRatedAppService, ILogger<UserController> logger)
        {
            _bharadaRatedAppService = bharadaRatedAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddGood")]
        public async Task AddUser([FromBody] BharadaRateInputDto input)
        {
            try
            {
                await _bharadaRatedAppService.CreateOrUpdateBharadaRate(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteBharadaRate")]
        public async Task DeleteBharadaRate(Guid id)
        {
            try
            {
                await _bharadaRatedAppService.DeleteBharadaRate(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllBharadaRate")]
        public async Task<List<BharadaRateDto>> GetAllBharadaRates()
        {
            try
            {
                return await _bharadaRatedAppService.GetAllBharadaRates();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<BharadaRateDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<BharadaRateDto> GetBharadaRate(Guid id)
        {
            try
            {
                return await _bharadaRatedAppService.GetBharadaRate(id);
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

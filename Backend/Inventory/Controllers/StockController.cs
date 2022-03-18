using Inventory.Application.Shared.Stocks;
using Inventory.Application.Shared.Stocks.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockAppService _stockAppService;
        private readonly ILogger<UserController> _logger;

        public StockController(IStockAppService stockAppService, ILogger<UserController> logger)
        {
            _stockAppService = stockAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddStock")]
        public async Task AddStock([FromBody] StockInputDto input)
        {
            try
            {
                await _stockAppService.CreateOrUpdateStock(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteStock")]
        public async Task DeleteStock(Guid id)
        {
            try
            {
                await _stockAppService.DeleteStock(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllStock")]
        public async Task<List<StockDto>> GetAllStocks()
        {
            try
            {
                return await _stockAppService.GetAllStocks();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<StockDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<StockDto> GetStock(Guid id)
        {
            try
            {
                return await _stockAppService.GetStock(id);
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

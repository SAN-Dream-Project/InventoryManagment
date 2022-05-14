using Inventory.Application.Shared.Purchases;
using Inventory.Application.Shared.Purchases.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseAppService _purchaseAppService;
        private readonly ILogger<UserController> _logger;

        public PurchaseController(IPurchaseAppService purchaseAppService, ILogger<UserController> logger)
        {
            _purchaseAppService = purchaseAppService;
            _logger = logger;
        }
        [HttpPost("AddPurchase")]
        public async Task AddPurchase([FromBody] PurchaseInputDto input)
        {
            try
            {
                await _purchaseAppService.CreateOrUpdatePurchase(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        [HttpDelete("DeletePurchase")]
        public async Task DeletePurchase(Guid id)
        {
            try
            {
                await _purchaseAppService.DeletePurchase(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        [HttpGet("GetAllPurchase")]
        public async Task<List<PurchaseDto>> GetAllKadatas()
        {
            try
            {
                return await _purchaseAppService.GetAllPurchases();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<PurchaseDto>();
            }
        }

        [HttpGet("GetById")]
        public async Task<PurchaseDto> GetKadata(Guid id)
        {
            try
            {
                return await _purchaseAppService.GetPurchase(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return null;
            }
        }

        [HttpGet("GetPurchaseAverageRates")]
        public async Task<List<PurchaseAverageDto>> GetPurchaseAverageRates()
        {
            try
            {
                return await _purchaseAppService.GetPurchaseAverageRates();
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

using Inventory.Application.Shared.GoodSuppliers;
using Inventory.Application.Shared.GoodSuppliers.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GoodSupplierController : ControllerBase
    {
        private readonly IGoodSupplierAppService _goodSupplierAppService;
        private readonly ILogger<UserController> _logger;

        public GoodSupplierController(IGoodSupplierAppService goodSupplierAppService, ILogger<UserController> logger)
        {
            _goodSupplierAppService = goodSupplierAppService;
            _logger = logger;
        }
        [HttpPost("AddGoodSupplier")]
        public async Task AddUser([FromBody] GoodSupplierInputDto input)
        {
            try
            {
                await _goodSupplierAppService.CreateOrUpdateGoodSupplier(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        [HttpDelete("DeleteGoodSupplier")]
        public async Task DeleteKadata(Guid id)
        {
            try
            {
                await _goodSupplierAppService.DeleteGoodSupplier(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        [HttpGet("GetAllGoodSupplier")]
        public async Task<List<GoodSupplierDto>> GetAllKadatas()
        {
            try
            {
                return await _goodSupplierAppService.GetAllGoodSuppliers();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<GoodSupplierDto>();
            }
        }

        [HttpGet("GetById")]
        public async Task<GoodSupplierDto> GetGoodSupplier(Guid id)
        {
            try
            {
                return await _goodSupplierAppService.GetGoodSupplier(id);
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

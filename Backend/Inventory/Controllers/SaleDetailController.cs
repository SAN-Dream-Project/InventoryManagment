using Inventory.Application.Shared.SaleDetails;
using Inventory.Application.Shared.SaleDetails.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
   
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailAppService _saleDetailAppService;
        private readonly ILogger<UserController> _logger;

        public SaleDetailController(ISaleDetailAppService saleDetailAppService, ILogger<UserController> logger)
        {
            _saleDetailAppService = saleDetailAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddSaleDetail")]
        public async Task AddSaleDetail([FromBody] SaleDetailInputDto input)
        {
            try
            {
                await _saleDetailAppService.CreateOrUpdateSaleDetail(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteSaleDetail")]
        public async Task DeleteSaleDetail(Guid id)
        {
            try
            {
                await _saleDetailAppService.DeleteSaleDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllSaleDetail")]
        public async Task<List<SaleDetailDto>> GetAllSaleDetails()
        {
            try
            {
                return await _saleDetailAppService.GetAllSaleDetails();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<SaleDetailDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<SaleDetailDto> GetSaleDetail(Guid id)
        {
            try
            {
                return await _saleDetailAppService.GetSaleDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return null;
            }
        }

        [HttpGet("GetSaleReportData")]
        public async Task<List<SaleDetailDto>> GetSaleReportData(SaleReportInputDto reportInputDto)
        {
            try
            {
                return await _saleDetailAppService.GetSaleReportData(reportInputDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<SaleDetailDto>();
            }
        }
    }
}

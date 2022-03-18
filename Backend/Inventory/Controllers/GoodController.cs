using Inventory.Application.Shared.Goods;
using Inventory.Application.Shared.Goods.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Host.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly IGoodAppService _goodAppService;
        private readonly ILogger<UserController> _logger;

        public GoodController(IGoodAppService goodAppService, ILogger<UserController> logger)
        {
            _goodAppService = goodAppService;
            _logger = logger;
        } //Add Role  
        [HttpPost("AddGood")]
        public async Task AddUser([FromBody] GoodInputDto input)
        {
            try
            {
                await _goodAppService.CreateOrUpdateGood(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //Delete User  
        [HttpDelete("DeleteGood")]
        public async Task DeleteGood(Guid id)
        {
            try
            {
                await _goodAppService.DeleteGood(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllGood")]
        public async Task<List<GoodDto>> GetAllGoods()
        {
            try
            {
                return await _goodAppService.GetAllGoods();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                return new List<GoodDto>();
            }
        }
        //GET All User by Name  
        [HttpGet("GetById")]
        public async Task<GoodDto> GetGood(Guid id)
        {
            try
            {
                return await _goodAppService.GetGood(id);
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

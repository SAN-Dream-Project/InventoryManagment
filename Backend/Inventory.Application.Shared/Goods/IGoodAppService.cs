using Inventory.Application.Shared.Dropdowns;
using Inventory.Application.Shared.Goods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Goods
{
    public interface IGoodAppService
    {
        Task CreateOrUpdateGood(GoodInputDto goodInputDto);
        Task DeleteGood(Guid goodId);
        Task<GoodDto> GetGood(Guid goodId);
        Task<List<GoodDto>> GetAllGoods();
        Task<List<Dropdown>> GetGoodList();
    }
}

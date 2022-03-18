using Inventory.Application.Shared.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Stocks
{
    public interface IStockAppService
    {
        Task CreateOrUpdateStock(StockInputDto stockInputDto);
        Task DeleteStock(Guid stockId);
        Task<StockDto> GetStock(Guid stockId);
        Task<List<StockDto>> GetAllStocks();
    }
}

using AutoMapper;
using Inventory.Application.Shared.Stocks;
using Inventory.Application.Shared.Stocks.Dto;
using Inventory.Core.Stocks;
using Inventory.EntityFramwork.Abstract.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Stocks
{
    public class StockAppService : IStockAppService
    {
        private readonly IStockRepository _stockRepository;

        public StockAppService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task CreateOrUpdateStock(StockInputDto goodInputDto)
        {
            if (goodInputDto.Id == null || goodInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<StockInputDto, Stock>(goodInputDto);
                await _stockRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<StockInputDto, Stock>(goodInputDto);
                await _stockRepository.Update(result);
            }
        }

        public async Task DeleteStock(Guid stockId)
        {
            var result = await _stockRepository.GetSingle(stockId);
            await _stockRepository.Delete(result);
        }

        public async Task<List<StockDto>> GetAllStocks()
        {
            var result = await _stockRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<StockDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Stock, StockDto>(test));
            }
            return roleList;
        }

        public async Task<StockDto> GetStock(Guid stockId)
        {
            var result = await _stockRepository.GetSingle(stockId);
            var returnResult = Mapper.Map<Stock, StockDto>(result);
            return returnResult;
        }
    }
}

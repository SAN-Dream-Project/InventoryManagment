using AutoMapper;
using Inventory.Application.Shared.Purchases;
using Inventory.Application.Shared.Purchases.Dto;
using Inventory.Application.Shared.Stocks;
using Inventory.Application.Shared.Stocks.Dto;
using Inventory.Core.Purchases;
using Inventory.EntityFramwork.Abstract.Purchases;
using Inventory.EntityFramwork.Abstract.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Purchases
{
    public class PurchaseAppService : IPurchaseAppService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStockAppService _IStockAppService;

        public PurchaseAppService(IPurchaseRepository purchaseRepository, IStockAppService IStockAppService)
        {
            _purchaseRepository = purchaseRepository;
            _IStockAppService = IStockAppService;
        }

        public async Task CreateOrUpdatePurchase(PurchaseInputDto purchaseInputDto)
        {
            var stock = new StockInputDto();
            stock.Id = Guid.Empty;
            stock.GoodID = purchaseInputDto.GoodID;
           
            if (purchaseInputDto.Id == null || purchaseInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<PurchaseInputDto, Purchase>(purchaseInputDto);
                var returnResult = await _purchaseRepository.Add(result);
                if (stock.GoodID != null || stock.GoodID != Guid.Empty)
                {
                    stock.Quantity = returnResult.GrossGoodQuantity;
                    await _IStockAppService.AddPurchesStock(stock);
                }

            }
            else
            {
                var result = Mapper.Map<PurchaseInputDto, Purchase>(purchaseInputDto);
                var returnResult = await _purchaseRepository.Update(result);
                if (stock.GoodID != null || stock.GoodID != Guid.Empty)
                {
                    stock.Quantity = returnResult.GrossGoodQuantity;
                    await _IStockAppService.AddPurchesStock(stock);
                }

            }
        }

        public async Task DeletePurchase(Guid purchaseId)
        {
            var result = await _purchaseRepository.GetSingle(purchaseId);
            await _purchaseRepository.Delete(result);
        }

        public async Task<List<PurchaseDto>> GetAllPurchases()
        {
                var result = _purchaseRepository.AllIncluding(g=>g.Good,gs=>gs.GoodSupplier,k=>k.Kadata,lr=>lr.LabourRate).ToList();
                var purchesResult = result.ToList();
                var purchesList = new List<PurchaseDto>();
                foreach (var test in purchesResult)
                {
                    purchesList.Add(Mapper.Map<Purchase, PurchaseDto>(test));
                }
                return purchesList;
        }

        public async Task<PurchaseDto> GetPurchase(Guid purchaseId)
        {
            var result = await _purchaseRepository.GetSingle(purchaseId);
            var returnResult = Mapper.Map<Purchase, PurchaseDto>(result);
            return returnResult;
        }

        public async Task<List<PurchaseAverageDto>> GetPurchaseAverageRates()
        {
            var result = _purchaseRepository.AllIncluding(g => g.Good).ToList();
            var filterByDate = result.Where(x =>Convert.ToDateTime(x.CreatedDate).Date == DateTime.Now.Date).Select(x=> new PurchaseAverageDto { GoodName = x.Good.GoodName,AverageRate = x.GoodRate});
            var finalResult = new List<PurchaseAverageDto>();
            foreach (var item in filterByDate)
            {
               int cnt = 0;
                double goodRateAvg = 0;
                foreach (var itemRate in filterByDate)
                {
                    if(item.GoodName == itemRate.GoodName)
                    {
                        cnt++;
                        goodRateAvg += (double)itemRate.AverageRate;
                    }
                }
                goodRateAvg = goodRateAvg / cnt;
                var avg = new PurchaseAverageDto();
                avg.GoodName=item.GoodName;
                avg.AverageRate=goodRateAvg;
                var res = finalResult.FirstOrDefault(x => x.GoodName == item.GoodName);
                if (res == null)
                {
                    finalResult.Add(avg);
                }
            }
            return finalResult.ToList();
        }
    }
}

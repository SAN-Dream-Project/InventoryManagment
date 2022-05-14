using Inventory.Application.Shared.Purchases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Purchases
{
    public interface IPurchaseAppService
    {
        Task CreateOrUpdatePurchase(PurchaseInputDto purchaseInputDto);
        Task DeletePurchase(Guid purchaseId);
        Task<PurchaseDto> GetPurchase(Guid purchaseId);
        Task<List<PurchaseDto>> GetAllPurchases();
        Task<List<PurchaseAverageDto>> GetPurchaseAverageRates();

    }
}

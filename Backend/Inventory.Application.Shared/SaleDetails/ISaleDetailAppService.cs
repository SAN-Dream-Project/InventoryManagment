using Inventory.Application.Shared.SaleDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.SaleDetails
{
    public interface ISaleDetailAppService
    {
        Task CreateOrUpdateSaleDetail(SaleDetailInputDto SaleDetailInputDto);
        Task DeleteSaleDetail(Guid SaleDetailId);
        Task<SaleDetailDto> GetSaleDetail(Guid SaleDetailId);
        Task<List<SaleDetailDto>> GetAllSaleDetails();
    }
}

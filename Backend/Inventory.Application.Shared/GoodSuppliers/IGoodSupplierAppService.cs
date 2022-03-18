using Inventory.Application.Shared.GoodSuppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.GoodSuppliers
{
    public interface IGoodSupplierAppService
    {
        Task CreateOrUpdateGoodSupplier(GoodSupplierInputDto goodSupplierInputDto);
        Task DeleteGoodSupplier(Guid goodSupplierId);
        Task<GoodSupplierDto> GetGoodSupplier(Guid goodSupplierId);
        Task<List<GoodSupplierDto>> GetAllGoodSuppliers();
    }
}

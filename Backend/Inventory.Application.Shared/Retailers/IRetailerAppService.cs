using Inventory.Application.Shared.Retailers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Retailers
{
    public interface IRetailerAppService
    {
        Task CreateOrUpdateRetailer(RetailerInputDto RetailerInputDto);
        Task DeleteRetailer(Guid retailerId);
        Task<RetailerDto> GetRetailer(Guid retailerId);
        Task<List<RetailerDto>> GetAllRetailers();
    }
}

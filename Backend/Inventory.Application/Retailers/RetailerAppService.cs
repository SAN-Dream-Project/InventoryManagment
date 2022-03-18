using Inventory.Application.Shared.Retailers;
using Inventory.Application.Shared.Retailers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Retailers
{
    public class RetailerAppService : IRetailerAppService
    {
        public Task CreateOrUpdateRetailer(RetailerInputDto RetailerInputDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRetailer(Guid retailerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RetailerDto>> GetAllRetailers()
        {
            throw new NotImplementedException();
        }

        public Task<RetailerDto> GetRetailer(Guid retailerId)
        {
            throw new NotImplementedException();
        }
    }
}

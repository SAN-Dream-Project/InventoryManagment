using Inventory.Application.Shared.Kadatas.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Kadatas
{
    public interface IKadataAppService
    {
        Task CreateOrUpdateKadata(KadataInputDto kadataInputDto);
        Task DeleteKadata(Guid kadataId);
        Task<KadataDto> GetKadata(Guid kadataId);
        Task<List<KadataDto>> GetAllKadatas();
    }
}

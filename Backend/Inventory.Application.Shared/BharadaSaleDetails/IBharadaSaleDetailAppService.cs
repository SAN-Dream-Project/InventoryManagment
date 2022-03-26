using Inventory.Application.Shared.BharadaSaleDetails.Dto;
using Inventory.Application.Shared.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.BharadaSaleDetails
{
    public interface IBharadaSaleDetailAppService
    {
        Task CreateOrUpdateBharadaSaleDetail(BharadaSaleDetailInputDto bharadaSaleDetailInputDto);
        Task DeleteBharadaSaleDetail(Guid bharadaSaleDetailId);
        Task<BharadaSaleDetailDto> GetBharadaSaleDetail(Guid bharadaSaleDetailId);
        Task<List<BharadaSaleDetailDto>> GetAllBharadaSaleDetails();
        Task<List<Dropdown>> GetBharadaSaleDetailList();
    }
}

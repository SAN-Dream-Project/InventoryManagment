using Inventory.Application.Shared.BharadaCreditDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.BharadaCreditDetails
{
    public interface IBharadaCreditDetailAppService
    {
        Task CreateOrUpdateBharadaCreditDetail(BharadaCreditDetailInputDto bharadaCreditDetailInputDto);
        Task DeleteBharadaCreditDetail(Guid bharadaCreditDetailId);
        Task<BharadaCreditDetailDto> GetBharadaCreditDetail(Guid bharadaCreditDetailId);
        Task<List<BharadaCreditDetailDto>> GetAllBharadaCreditDetails();
    }
}

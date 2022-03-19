using Inventory.Application.Shared.LabourDetails.Dto;
using Inventory.Application.Shared.LabourRates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.LabourDetails
{
    public interface ILabourDetailAppService
    {
        Task CreateOrUpdateLabourDetail(LabourDetailInputDto labourDetailInputDto);
        Task DeleteLabourDetail(Guid labourDetailId);
        Task<LabourDetailDto> GetLabourDetail(Guid labourDetailId);
        Task<List<LabourDetailDto>> GetAllLabourDetails();
    }
}

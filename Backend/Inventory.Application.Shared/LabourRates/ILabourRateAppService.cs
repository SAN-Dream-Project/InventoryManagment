using Inventory.Application.Shared.LabourRates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.LabourRates
{
    public interface ILabourRateAppService
    {
        Task CreateOrUpdateLabourRate(LabourRateInputDto labourRateInputDto);
        Task DeleteLabourRate(Guid userRateId);
        Task<LabourRateDto> GetLabourRate(Guid labourRateId);
        Task<List<LabourRateDto>> GetAllLabourRates();
    }
}

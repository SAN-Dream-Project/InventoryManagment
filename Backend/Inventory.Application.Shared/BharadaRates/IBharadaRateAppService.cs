using Inventory.Application.Shared.BharadaRates.Dto;
using Inventory.Application.Shared.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.BharadaRates
{
    public interface IBharadaRateAppService
    {
        Task CreateOrUpdateBharadaRate(BharadaRateInputDto bharadaRateInputDto);
        Task DeleteBharadaRate(Guid bharadaRateId);
        Task<BharadaRateDto> GetBharadaRate(Guid bharadaRateId);
        Task<List<BharadaRateDto>> GetAllBharadaRates();

        Task<List<Dropdown>> GetBharadaRateList();
    }
}

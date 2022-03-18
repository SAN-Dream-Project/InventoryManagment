using Inventory.Application.Shared.Labours.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Labours
{
    public interface ILabourAppService
    {
        Task CreateOrUpdateLabour(LabourInputDto labourInputDto);
        Task DeleteLabour(Guid goodId);
        Task<LabourDto> GetLabour(Guid goodId);
        Task<List<LabourDto>> GetAllLabours();
    }
}

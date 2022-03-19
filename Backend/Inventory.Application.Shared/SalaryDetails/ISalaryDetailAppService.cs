using Inventory.Application.Shared.SalaryDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.SalaryDetails
{
    public interface ISalaryDetailAppService
    {
        Task CreateOrUpdateSalaryDetail(SalaryDetailInputDto salaryDetailInputDto);
        Task DeleteSalaryDetail(Guid salaryDetailId);
        Task<SalaryDetailDto> GetSalaryDetail(Guid salaryDetailId);
        Task<List<SalaryDetailDto>> GetAllSalaryDetails();
    }
}

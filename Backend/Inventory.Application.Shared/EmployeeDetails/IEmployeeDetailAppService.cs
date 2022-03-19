using Inventory.Application.Shared.EmployeeDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.EmployeeDetails
{
    public interface IEmployeeDetailAppService
    {
        Task CreateOrUpdateEmployeeDetail(EmployeeDetailInputDto employeeDetailInputDto);
        Task DeleteEmployeeDetail(Guid employeeDetailId);
        Task<EmployeeDetailDto> GetEmployeeDetail(Guid goodId);
        Task<List<EmployeeDetailDto>> GetAllEmployeeDetails();
    }
}

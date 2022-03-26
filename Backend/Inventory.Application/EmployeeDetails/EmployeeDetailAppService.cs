using AutoMapper;
using Inventory.Application.Shared.Dropdowns;
using Inventory.Application.Shared.EmployeeDetails;
using Inventory.Application.Shared.EmployeeDetails.Dto;
using Inventory.Core.EmplyeeDetails;
using Inventory.EntityFramwork.Abstract.EmplyeeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.EmployeeDetails
{
    public class EmployeeDetailAppService : IEmployeeDetailAppService
    {
        private readonly IEmployeeDetailRepository _employeeDetailRepository;

        public EmployeeDetailAppService(IEmployeeDetailRepository employeeDetailRepository)
        {
            _employeeDetailRepository = employeeDetailRepository;
        }

        public async Task CreateOrUpdateEmployeeDetail(EmployeeDetailInputDto employeeDetailInputDto)
        {
            if (employeeDetailInputDto.Id == null || employeeDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<EmployeeDetailInputDto, EmployeeDetail>(employeeDetailInputDto);
                await _employeeDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<EmployeeDetailInputDto, EmployeeDetail>(employeeDetailInputDto);
                await _employeeDetailRepository.Update(result);
            }
        }

        public async Task DeleteEmployeeDetail(Guid employeeDetailId)
        {
            var result = await _employeeDetailRepository.GetSingle(employeeDetailId);
            await _employeeDetailRepository.Delete(result);
        }

        public async Task<List<EmployeeDetailDto>> GetAllEmployeeDetails()
        {
            var result = await _employeeDetailRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<EmployeeDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<EmployeeDetail, EmployeeDetailDto>(test));
            }
            return roleList;
        }

        public async Task<EmployeeDetailDto> GetEmployeeDetail(Guid employeeDetailId)
        {
            var result = await _employeeDetailRepository.GetSingle(employeeDetailId);
            var returnResult = Mapper.Map<EmployeeDetail, EmployeeDetailDto>(result);
            return returnResult;
        }
        public async Task<List<Dropdown>> GetEmployeeList()
        {
            return _employeeDetailRepository.GetAll().Result.
                Select(x => new Dropdown() { Key = x.Id, Value = x.FirstName+" "+x.MiddleName+" "+x.LastName }).ToList();

        }
    }
}

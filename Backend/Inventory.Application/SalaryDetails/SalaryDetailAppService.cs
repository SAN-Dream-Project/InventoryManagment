using AutoMapper;
using Inventory.Application.Shared.SalaryDetails;
using Inventory.Application.Shared.SalaryDetails.Dto;
using Inventory.Core.SalaryDetails;
using Inventory.EntityFramwork.Abstract.SalaryDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.SalaryDetails
{
    public class SalaryDetailAppService : ISalaryDetailAppService
    {
        private readonly ISalaryDetailRepository _salaryDetailRepository;

        public SalaryDetailAppService(ISalaryDetailRepository salaryDetailRepository)
        {
            _salaryDetailRepository = salaryDetailRepository;
        }

        public async Task CreateOrUpdateSalaryDetail(SalaryDetailInputDto salaryDetailInputDto)
        {
            if (salaryDetailInputDto.Id == null || salaryDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<SalaryDetailInputDto, SalaryDetail>(salaryDetailInputDto);
                await _salaryDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<SalaryDetailInputDto, SalaryDetail>(salaryDetailInputDto);
                await _salaryDetailRepository.Update(result);
            }
        }

        public async Task DeleteSalaryDetail(Guid salaryDetailId)
        {
            var result = await _salaryDetailRepository.GetSingle(salaryDetailId);
            await _salaryDetailRepository.Delete(result);
        }

        public async Task<List<SalaryDetailDto>> GetAllSalaryDetails()
        {
            var result = await _salaryDetailRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<SalaryDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<SalaryDetail, SalaryDetailDto>(test));
            }
            return roleList;
        }

        public async Task<SalaryDetailDto> GetSalaryDetail(Guid goodId)
        {
            var result = await _salaryDetailRepository.GetSingle(goodId);
            var returnResult = Mapper.Map<SalaryDetail, SalaryDetailDto>(result);
            return returnResult;
        }
    }
}

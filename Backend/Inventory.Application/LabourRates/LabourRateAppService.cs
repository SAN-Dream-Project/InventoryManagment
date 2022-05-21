using AutoMapper;
using Inventory.Application.Shared.Dropdowns;
using Inventory.Application.Shared.LabourRates;
using Inventory.Application.Shared.LabourRates.Dto;
using Inventory.Core.LabourRates;
using Inventory.EntityFramwork.Abstract.LabourRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.LabourRates
{
    public class LabourRateAppService : ILabourRateAppService
    {
        private readonly ILabourRateRepository _labourRateRepository;

        public LabourRateAppService(ILabourRateRepository labourRateRepository)
        {
            _labourRateRepository = labourRateRepository;
        }

        public async Task CreateOrUpdateLabourRate(LabourRateInputDto labouRateInputDto)
        {
            if (labouRateInputDto.Id == null || labouRateInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<LabourRateInputDto, LabourRate>(labouRateInputDto);
                await _labourRateRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<LabourRateInputDto, LabourRate>(labouRateInputDto);
                await _labourRateRepository.Update(result);
            }
        }

        public async Task DeleteLabourRate(Guid labourRateId)
        {
            var result = await _labourRateRepository.GetSingle(labourRateId);
            await _labourRateRepository.Delete(result);
        }

        public async Task<List<LabourRateDto>> GetAllLabourRates()
        {
            var result = await _labourRateRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<LabourRateDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<LabourRate, LabourRateDto>(test));
            }
            return roleList;
        }

        public async Task<LabourRateDto> GetLabourRate(Guid labourRateId)
        {
            var result = await _labourRateRepository.GetSingle(labourRateId);
            var returnResult = Mapper.Map<LabourRate, LabourRateDto>(result);
            return returnResult;
        }
        public async Task<List<Dropdown>> GetLabourRateList()
        {
            return _labourRateRepository.GetAll().Result.
                Select(x => new Dropdown() { Key = x.Id, Value = x.Rate.ToString() }).ToList();

        }
    }
}

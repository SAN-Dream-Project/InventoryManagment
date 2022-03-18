using AutoMapper;
using Inventory.Application.Shared.Labours;
using Inventory.Application.Shared.Labours.Dto;
using Inventory.Core.Labours;
using Inventory.EntityFramwork.Abstract.Labours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Labours
{
    public class LabourAppService : ILabourAppService
    {
        private readonly ILabourRepository _labourRepository;

        public LabourAppService(ILabourRepository labourRepository)
        {
            _labourRepository = labourRepository;
        }

        public async Task CreateOrUpdateLabour(LabourInputDto labourInputDto)
        {
            if (labourInputDto.Id == null || labourInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<LabourInputDto, Labour>(labourInputDto);
                await _labourRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<LabourInputDto, Labour>(labourInputDto);
                await _labourRepository.Update(result);
            }
        }

        public async Task DeleteLabour(Guid labourId)
        {
            var result = await _labourRepository.GetSingle(labourId);
            await _labourRepository.Delete(result);
        }

        public async Task<List<LabourDto>> GetAllLabours()
        {
            var result = await _labourRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<LabourDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Labour, LabourDto>(test));
            }
            return roleList;
        }

        public async Task<LabourDto> GetLabour(Guid labourId)
        {
            var result = await _labourRepository.GetSingle(labourId);
            var returnResult = Mapper.Map<Labour, LabourDto>(result);
            return returnResult;
        }
    }
}

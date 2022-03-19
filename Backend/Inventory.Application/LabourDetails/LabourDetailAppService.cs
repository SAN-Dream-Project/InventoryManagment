using AutoMapper;
using Inventory.Application.Shared.LabourDetails;
using Inventory.Application.Shared.LabourDetails;
using Inventory.Application.Shared.LabourDetails.Dto;
using Inventory.Core.LabourDetails;
using Inventory.EntityFramwork.Abstract.LabourDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.LabourDetails
{
    public class LabourDetailAppService : ILabourDetailAppService
    {
        private readonly ILabourDetailRepository _labourDetailRepository;

        public LabourDetailAppService(ILabourDetailRepository labourDetailRepository)
        {
            _labourDetailRepository = labourDetailRepository;
        }

        public async Task CreateOrUpdateLabourDetail(LabourDetailInputDto labourDetailInputDto)
        {
            if (labourDetailInputDto.Id == null || labourDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<LabourDetailInputDto, LabourDetail>(labourDetailInputDto);
                await _labourDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<LabourDetailInputDto, LabourDetail>(labourDetailInputDto);
                await _labourDetailRepository.Update(result);
            }
        }

        public async Task DeleteLabourDetail(Guid labourDetailId)
        {
            var result = await _labourDetailRepository.GetSingle(labourDetailId);
            await _labourDetailRepository.Delete(result);
        }

        public async Task<List<LabourDetailDto>> GetAllLabourDetails()
        {
            var result = await _labourDetailRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<LabourDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<LabourDetail, LabourDetailDto>(test));
            }
            return roleList;
        }

        public async Task<LabourDetailDto> GetLabourDetail(Guid labourDetailId)
        {
            var result = await _labourDetailRepository.GetSingle(labourDetailId);
            var returnResult = Mapper.Map<LabourDetail, LabourDetailDto>(result);
            return returnResult;
        }
    }
}

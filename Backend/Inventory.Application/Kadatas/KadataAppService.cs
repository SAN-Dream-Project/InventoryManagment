using AutoMapper;
using Inventory.Application.Shared.Kadatas;
using Inventory.Application.Shared.Kadatas.Dto;
using Inventory.Core.Kadatas;
using Inventory.EntityFramwork.Abstract.Kadatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Kadatas
{
    public class KadataAppService : IKadataAppService
    {
        private readonly IKadataRepository _kadataRepository;

        public KadataAppService(IKadataRepository kadataRepository)
        {
            _kadataRepository = kadataRepository;
        }

        public async Task CreateOrUpdateKadata(KadataInputDto kadataInputDto)
        {
            if (kadataInputDto.Id == null || kadataInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<KadataInputDto, Kadata>(kadataInputDto);
                await _kadataRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<KadataInputDto, Kadata>(kadataInputDto);
                await _kadataRepository.Update(result);
            }
        }

        public async Task DeleteKadata(Guid kadataId)
        {
            var result = await _kadataRepository.GetSingle(kadataId);
            await _kadataRepository.Delete(result);
        }

        public async Task<List<KadataDto>> GetAllKadatas()
        {
            var result = await _kadataRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<KadataDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Kadata, KadataDto>(test));
            }
            return roleList;
        }

        public async Task<KadataDto> GetKadata(Guid kadataId)
        {
            var result = await _kadataRepository.GetSingle(kadataId);
            var returnResult = Mapper.Map<Kadata, KadataDto>(result);
            return returnResult;
        }
    }
}

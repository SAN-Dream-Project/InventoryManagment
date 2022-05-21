using AutoMapper;
using Inventory.Application.Shared.BharadaRates;
using Inventory.Application.Shared.BharadaRates.Dto;
using Inventory.Application.Shared.Dropdowns;
using Inventory.Core.RateTables;
using Inventory.EntityFramwork.Abstract.BharadaRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.BharadaRates
{
    public class BharadaRateAppService : IBharadaRateAppService
    {
        private readonly IBharadaRateRepository _bharadaRateRepository;

        public BharadaRateAppService(IBharadaRateRepository bharadaRateRepository)
        {
            _bharadaRateRepository = bharadaRateRepository;
        }

        public async Task CreateOrUpdateBharadaRate(BharadaRateInputDto bharadaRateInputDto)
        {
            if (bharadaRateInputDto.Id == null || bharadaRateInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<BharadaRateInputDto, BharadaRate>(bharadaRateInputDto);
                await _bharadaRateRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<BharadaRateInputDto, BharadaRate>(bharadaRateInputDto);
                await _bharadaRateRepository.Update(result);
            }
        }

        public async Task DeleteBharadaRate(Guid bharadaRateId)
        {
            var result = await _bharadaRateRepository.GetSingle(bharadaRateId);
            await _bharadaRateRepository.Delete(result);
        }

        public async Task<List<BharadaRateDto>> GetAllBharadaRates()
        {
            var result = await _bharadaRateRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<BharadaRateDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<BharadaRate, BharadaRateDto>(test));
            }
            return roleList;
        }

        public async Task<BharadaRateDto> GetBharadaRate(Guid bharadaRateId)
        {
            var result = await _bharadaRateRepository.GetSingle(bharadaRateId);
            var returnResult = Mapper.Map<BharadaRate, BharadaRateDto>(result);
            return returnResult;
        }
        public async Task<List<Dropdown>> GetBharadaRateList()
        {
            return _bharadaRateRepository.GetAll().Result.
                Select(x => new Dropdown() { Key = x.Id, Value = x.RateCriteria }).ToList();

        }
    }
}

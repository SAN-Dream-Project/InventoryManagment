using AutoMapper;
using Inventory.Application.Shared.BharadaSaleDetails;
using Inventory.Application.Shared.BharadaSaleDetails.Dto;
using Inventory.Application.Shared.Dropdowns;
using Inventory.Core.BharadaSaleDetails;
using Inventory.EntityFramwork.Abstract.BharadaSaleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.BharataSaleDetails
{
    public class BharadaSaleDetailAppService: IBharadaSaleDetailAppService
    {
        private readonly IBharadaSaleDetailRepository _bharadaSaleDetailRepository;

        public BharadaSaleDetailAppService(IBharadaSaleDetailRepository bharadaSaleDetailRepository)
        {
            _bharadaSaleDetailRepository = bharadaSaleDetailRepository;
        }

        public async Task CreateOrUpdateBharadaSaleDetail(BharadaSaleDetailInputDto BharadaSaleDetailInputDto)
        {
            if (BharadaSaleDetailInputDto.Id == null || BharadaSaleDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<BharadaSaleDetailInputDto, BharadaSaleDetail>(BharadaSaleDetailInputDto);
                await _bharadaSaleDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<BharadaSaleDetailInputDto, BharadaSaleDetail>(BharadaSaleDetailInputDto);
                await _bharadaSaleDetailRepository.Update(result);
            }
        }

        public async Task DeleteBharadaSaleDetail(Guid BharadaSaleDetailId)
        {
            var result = await _bharadaSaleDetailRepository.GetSingle(BharadaSaleDetailId);
            await _bharadaSaleDetailRepository.Delete(result);
        }

        public async Task<List<BharadaSaleDetailDto>> GetAllBharadaSaleDetails()
        {
            var result = await _bharadaSaleDetailRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<BharadaSaleDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<BharadaSaleDetail, BharadaSaleDetailDto>(test));
            }
            return roleList;
        }

        public async Task<BharadaSaleDetailDto> GetBharadaSaleDetail(Guid BharadaSaleDetailId)
        {
            var result = await _bharadaSaleDetailRepository.GetSingle(BharadaSaleDetailId);
            var returnResult = Mapper.Map<BharadaSaleDetail, BharadaSaleDetailDto>(result);
            return returnResult;
        }
        public async Task<List<Dropdown>> GetBharadaSaleDetailList()
        {
            return _bharadaSaleDetailRepository.GetAll().Result.
                Select(x => new Dropdown() { Key = x.Id, Value = x.Quntity.ToString() }).ToList();

        }
    }
}

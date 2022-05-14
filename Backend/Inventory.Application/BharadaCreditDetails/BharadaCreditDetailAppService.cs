using AutoMapper;
using Inventory.Application.Shared.BharadaCreditDetails;
using Inventory.Application.Shared.BharadaCreditDetails.Dto;
using Inventory.Core.BharadaCreditDetails;
using Inventory.EntityFramwork.Abstract.BharadaCreditDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.BharadaCreditDetails
{
    public class BharadaCreditDetailAppService: IBharadaCreditDetailAppService
    {
        private readonly IBharadaCreditDetailRepository _bharadaCreditDetailRepository;

        public BharadaCreditDetailAppService(IBharadaCreditDetailRepository bharadaCreditDetailRepository)
        {
            _bharadaCreditDetailRepository = bharadaCreditDetailRepository;
        }

        public async Task CreateOrUpdateBharadaCreditDetail(BharadaCreditDetailInputDto BharadaCreditDetailInputDto)
        {
            if (BharadaCreditDetailInputDto.Id == null || BharadaCreditDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<BharadaCreditDetailInputDto, BharadaCreditDetail>(BharadaCreditDetailInputDto);
                await _bharadaCreditDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<BharadaCreditDetailInputDto, BharadaCreditDetail>(BharadaCreditDetailInputDto);
                await _bharadaCreditDetailRepository.Update(result);
            }
        }

        public async Task DeleteBharadaCreditDetail(Guid BharadaCreditDetailId)
        {
            var result = await _bharadaCreditDetailRepository.GetSingle(BharadaCreditDetailId);
            await _bharadaCreditDetailRepository.Delete(result);
        }

        public async Task<List<BharadaCreditDetailDto>> GetAllBharadaCreditDetails()
        {
            var result =  _bharadaCreditDetailRepository.AllIncluding(r=>r.Retailer,bs=>bs.BharataSaleDetail).ToList();
            var roleResult = result.ToList();
            var roleList = new List<BharadaCreditDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<BharadaCreditDetail, BharadaCreditDetailDto>(test));
            }
            return roleList;
        }

        public async Task<BharadaCreditDetailDto> GetBharadaCreditDetail(Guid BharadaCreditDetailId)
        {
            var result = await _bharadaCreditDetailRepository.GetSingle(BharadaCreditDetailId);
            var returnResult = Mapper.Map<BharadaCreditDetail, BharadaCreditDetailDto>(result);
            return returnResult;
        }
    }
}

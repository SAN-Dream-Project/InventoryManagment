using AutoMapper;
using Inventory.Application.Shared.SaleDetails;
using Inventory.Application.Shared.SaleDetails.Dto;
using Inventory.Core.SaleDetails;
using Inventory.EntityFramwork.Abstract.SaleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.SaleDetails
{
    public class SaleDetailAppService : ISaleDetailAppService
    {
        private readonly ISaleDetailRepository _saleDetailRepository;

        public SaleDetailAppService(ISaleDetailRepository saleDetailRepository)
        {
            _saleDetailRepository = saleDetailRepository;
        }

        public async Task CreateOrUpdateSaleDetail(SaleDetailInputDto SaleDetailInputDto)
        {
            if (SaleDetailInputDto.Id == null || SaleDetailInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<SaleDetailInputDto, SaleDetail>(SaleDetailInputDto);
                await _saleDetailRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<SaleDetailInputDto, SaleDetail>(SaleDetailInputDto);
                await _saleDetailRepository.Update(result);
            }
        }

        public async Task DeleteSaleDetail(Guid SaleDetailId)
        {
            var result = await _saleDetailRepository.GetSingle(SaleDetailId);
            await _saleDetailRepository.Delete(result);
        }

        public async Task<List<SaleDetailDto>> GetAllSaleDetails()
        {
            var result =  _saleDetailRepository.AllIncluding(g=>g.Good,gs=>gs.GoodSupplier,lr=>lr.LabourRate).ToList();
            var roleResult = result.ToList();
            var roleList = new List<SaleDetailDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<SaleDetail, SaleDetailDto>(test));
            }
            return roleList;
        }

        public async Task<SaleDetailDto> GetSaleDetail(Guid goodId)
        {
            var result = await _saleDetailRepository.GetSingle(goodId);
            var returnResult = Mapper.Map<SaleDetail, SaleDetailDto>(result);
            return returnResult;
        }
    }
}

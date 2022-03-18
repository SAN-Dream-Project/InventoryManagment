using AutoMapper;
using Inventory.Application.Shared.Goods;
using Inventory.Application.Shared.Goods.Dto;
using Inventory.Core.Goods;
using Inventory.EntityFramwork.Abstract.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Goods
{
    public class GoodAppService : IGoodAppService
    {
        private readonly IGoodRepository _goodRepository;

        public GoodAppService(IGoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        public async Task CreateOrUpdateGood(GoodInputDto goodInputDto)
        {
            if (goodInputDto.Id == null || goodInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<GoodInputDto, Good>(goodInputDto);
                await _goodRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<GoodInputDto, Good>(goodInputDto);
                await _goodRepository.Update(result);
            }
        }

        public async Task DeleteGood(Guid goodId)
        {
            var result = await _goodRepository.GetSingle(goodId);
            await _goodRepository.Delete(result);
        }

        public async Task<List<GoodDto>> GetAllGoods()
        {
            var result = await _goodRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<GoodDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Good, GoodDto>(test));
            }
            return roleList;
        }

        public async Task<GoodDto> GetGood(Guid goodId)
        {
            var result = await _goodRepository.GetSingle(goodId);
            var returnResult = Mapper.Map<Good, GoodDto>(result);
            return returnResult;
        }
    }
}

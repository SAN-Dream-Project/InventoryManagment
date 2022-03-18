using AutoMapper;
using Inventory.Application.Shared.GoodSuppliers;
using Inventory.Application.Shared.GoodSuppliers.Dto;
using Inventory.Core.GoodSuppliers;
using Inventory.EntityFramwork.Abstract.GoodSuppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.GoodSuppliers
{
    public class GoodSupplierAppService : IGoodSupplierAppService
    {
        private readonly IGoodSupplierRepository _goodSupplierRepository;

        public GoodSupplierAppService(IGoodSupplierRepository goodSupplierRepository)
        {
            _goodSupplierRepository = goodSupplierRepository;
        }

        public async Task CreateOrUpdateGoodSupplier(GoodSupplierInputDto goodsupplierInputDto)
        {
            if (goodsupplierInputDto.Id == null || goodsupplierInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<GoodSupplierInputDto, GoodSupplier>(goodsupplierInputDto);
                await _goodSupplierRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<GoodSupplierInputDto, GoodSupplier>(goodsupplierInputDto);
                await _goodSupplierRepository.Update(result);
            }
        }

        public async Task DeleteGoodSupplier(Guid goodSupplierId)
        {
            var result = await _goodSupplierRepository.GetSingle(goodSupplierId);
            await _goodSupplierRepository.Delete(result);
        }

        public async Task<List<GoodSupplierDto>> GetAllGoodSuppliers()
        {
            var result = await _goodSupplierRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<GoodSupplierDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<GoodSupplier, GoodSupplierDto>(test));
            }
            return roleList;
        }

        public async Task<GoodSupplierDto> GetGoodSupplier(Guid goodSupplierId)
        {
            var result = await _goodSupplierRepository.GetSingle(goodSupplierId);
            var returnResult = Mapper.Map<GoodSupplier, GoodSupplierDto>(result);
            return returnResult;
        }
    }
}

using AutoMapper;
using Inventory.Application.Shared.Dropdowns;
using Inventory.Application.Shared.Retailers;
using Inventory.Application.Shared.Retailers.Dto;
using Inventory.Core.Retailers;
using Inventory.EntityFramwork.Abstract.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Retailers
{
    public class RetailerAppService : IRetailerAppService
    {
        private readonly IRetailerRepository _retailerRepository;

        public RetailerAppService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }

        public async Task CreateOrUpdateRetailer(RetailerInputDto retailerInputDto)
        {
            if (retailerInputDto.Id == null || retailerInputDto.Id == Guid.Empty)
            {
                var result = Mapper.Map<RetailerInputDto, Retailer>(retailerInputDto);
                await _retailerRepository.Add(result);
            }
            else
            {
                var result = Mapper.Map<RetailerInputDto, Retailer>(retailerInputDto);
                await _retailerRepository.Update(result);
            }
        }

        public async Task DeleteRetailer(Guid retailerId)
        {
            var result = await _retailerRepository.GetSingle(retailerId);
            await _retailerRepository.Delete(result);
        }

        public async Task<List<RetailerDto>> GetAllRetailers()
        {
            var result = await _retailerRepository.GetAll();
            var roleResult = result.ToList();
            var roleList = new List<RetailerDto>();
            foreach (var test in roleResult)
            {
                roleList.Add(Mapper.Map<Retailer, RetailerDto>(test));
            }
            return roleList;
        }

        public async Task<RetailerDto> GetRetailer(Guid retailerId)
        {
            var result = await _retailerRepository.GetSingle(retailerId);
            var returnResult = Mapper.Map<Retailer, RetailerDto>(result);
            return returnResult;
        }

        public async Task<List<Dropdown>> GetRetailerList()
        {
            return _retailerRepository.GetAll().Result.
                Select(x => new Dropdown() { Key = x.Id, Value = x.FirstName + " " + x.MiddleName + " " + x.LastName }).ToList();

        }
    }
}

using AutoMapper;
using Inventory.Application.Shared.EmployeeDetails.Dto;
using Inventory.Application.Shared.BharadaRates.Dto;
using Inventory.Application.Shared.Goods.Dto;
using Inventory.Application.Shared.GoodSuppliers.Dto;
using Inventory.Application.Shared.Kadatas.Dto;
using Inventory.Application.Shared.LabourRates.Dto;
using Inventory.Application.Shared.Labours.Dto;
using Inventory.Application.Shared.Retailers.Dto;
using Inventory.Application.Shared.SalaryDetails.Dto;
using Inventory.Application.Shared.Stocks.Dto;
using Inventory.Application.Shared.UserAndRoles.Roles.Dto;
using Inventory.Application.Shared.UserAndRoles.Users.Dto;
using Inventory.Core.EmplyeeDetails;
using Inventory.Core.Goods;
using Inventory.Core.GoodSuppliers;
using Inventory.Core.Kadatas;
using Inventory.Core.LabourRates;
using Inventory.Core.Labours;
using Inventory.Core.RateTables;
using Inventory.Core.Retailers;
using Inventory.Core.SalaryDetails;
using Inventory.Core.Stocks;
using Inventory.Core.UserAndRoles.Users;
using Inventory.Core.Users.Roles;

namespace Inventory.Application
{
   public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleInputDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserInputDto>().ReverseMap();
            CreateMap<Good, GoodInputDto>().ReverseMap();
            CreateMap<Good, GoodDto>().ReverseMap();
            CreateMap<Labour, LabourInputDto>().ReverseMap();
            CreateMap<Labour, LabourDto>().ReverseMap();
            CreateMap<Kadata, KadataInputDto>().ReverseMap();
            CreateMap<Kadata, KadataDto>().ReverseMap();
            CreateMap<GoodSupplier, GoodSupplierInputDto>().ReverseMap();
            CreateMap<GoodSupplier, GoodSupplierDto>().ReverseMap(); 
            CreateMap<Stock, StockInputDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap(); 
            CreateMap<Retailer, RetailerInputDto>().ReverseMap();
            CreateMap<Retailer, RetailerDto>().ReverseMap();
            CreateMap<LabourRate, LabourRateInputDto>().ReverseMap();
            CreateMap<LabourRate, LabourRateDto>().ReverseMap();
            CreateMap<EmployeeDetail, EmployeeDetailInputDto>().ReverseMap();
            CreateMap<EmployeeDetail, EmployeeDetailDto>().ReverseMap();
            CreateMap<SalaryDetail, SalaryDetailInputDto>().ReverseMap();
            CreateMap<SalaryDetail, SalaryDetailDto>().ReverseMap();
            CreateMap<Retailer, RetailerDto>().ReverseMap();
            CreateMap<BharadaRate, BharadaRateInputDto>().ReverseMap();
            CreateMap<BharadaRate, BharadaRateDto>().ReverseMap();
        }
    }
}

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
using Inventory.Core.Purchases;
using Inventory.Application.Shared.Purchases.Dto;
using Inventory.Core.LabourDetails;
using Inventory.Application.Shared.LabourDetails.Dto;
using Inventory.Core.SaleDetails;
using Inventory.Application.Shared.SaleDetails.Dto;
using Inventory.Core.BharadaSaleDetails;
using Inventory.Application.Shared.BharadaSaleDetails.Dto;
using Inventory.Core.BharadaCreditDetails;
using Inventory.Application.Shared.BharadaCreditDetails.Dto;

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
            CreateMap<Stock, StockDto>().ForMember(d => d.GoodName, o => o.MapFrom(s => s.Good.GoodName));
            CreateMap<StockDto, Stock>();
            CreateMap<Retailer, RetailerInputDto>().ReverseMap();
            CreateMap<Retailer, RetailerDto>().ReverseMap();
            CreateMap<LabourRate, LabourRateInputDto>().ReverseMap();
            CreateMap<LabourRate, LabourRateDto>().ReverseMap();
            CreateMap<EmployeeDetail, EmployeeDetailInputDto>().ReverseMap();
            CreateMap<EmployeeDetail, EmployeeDetailDto>().ReverseMap();
            CreateMap<SalaryDetail, SalaryDetailInputDto>().ReverseMap();
            CreateMap<SalaryDetail, SalaryDetailDto>().ReverseMap();
            CreateMap<BharadaRate, BharadaRateInputDto>().ReverseMap();
            CreateMap<BharadaRate, BharadaRateDto>().ReverseMap();
            CreateMap<Purchase, PurchaseInputDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ForMember(d => d.GoodName, o => o.MapFrom(s => s.Good.GoodName)).
            ForMember(d => d.GoodSupplierName, o => o.MapFrom(s => s.GoodSupplier.FirstName+" "+s.GoodSupplier.MiddleName+" "+s.GoodSupplier.LastName)).
            ForMember(d => d.KadataQuantity, o => o.MapFrom(s => s.Kadata.KadtaQuantity)).
            ForMember(d => d.LabourRate, o => o.MapFrom(s => s.LabourRate.Rate));
            CreateMap<PurchaseDto, Purchase>();
            CreateMap<LabourDetail, LabourDetailInputDto>().ReverseMap();
            CreateMap<LabourDetail, LabourDetailDto>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailInputDto>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailDto>().ForMember(d => d.GoodName, o => o.MapFrom(s => s.Good.GoodName)).
            ForMember(d => d.GoodSupplierName, o => o.MapFrom(s => s.GoodSupplier.FirstName + " " + s.GoodSupplier.MiddleName + " " + s.GoodSupplier.LastName)).
            ForMember(d => d.LabourRate, o => o.MapFrom(s => s.LabourRate.Rate));
            CreateMap<SaleDetailDto, SaleDetail>();
            CreateMap<BharadaSaleDetail, BharadaSaleDetailInputDto>().ReverseMap();
            CreateMap<BharadaSaleDetail, BharadaSaleDetailDto>().ForMember(d => d.BharadaRate, o => o.MapFrom(s => s.BharadaRate.Rate)).
            ForMember(d => d.RetailerName, o => o.MapFrom(s => s.Retailer.FirstName + " " + s.Retailer.MiddleName + " " + s.Retailer.LastName)).
            ForMember(d => d.LabourRate, o => o.MapFrom(s => s.LabourRate.Rate));
            CreateMap<BharadaSaleDetailDto, BharadaSaleDetail>();
            CreateMap<BharadaCreditDetail, BharadaCreditDetailInputDto>().ReverseMap();
            CreateMap<BharadaCreditDetail, BharadaCreditDetailDto>().ForMember(d => d.RemaningAmount, o => o.MapFrom(s => s.BharataSaleDetail.RemainingAmount)).
            ForMember(d => d.TotalAmount, o => o.MapFrom(s => s.BharataSaleDetail.TotalAmount)).
            ForMember(d => d.RetailerName, o => o.MapFrom(s => s.Retailer.FirstName + " " + s.Retailer.MiddleName + " " + s.Retailer.LastName));
            CreateMap<BharadaCreditDetailDto, BharadaCreditDetail>();
        }
    }
}

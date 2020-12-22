using Csp.DAL.Models;
using AutoMapper;
using Csp.Api.Models;
using System;

namespace Csp.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserItem>().ReverseMap();
            CreateMap<RequestMasterData, MasterProGroup>().ReverseMap();
            CreateMap<RequestMasterData, MasterProType>().ReverseMap();
            CreateMap<RequestMasterData, MasterProBrand>().ReverseMap();
            CreateMap<RequestMasterData, MasterPromodel>().ReverseMap();
            CreateMap<RequestMasterData, MasterProSize>().ReverseMap();
            CreateMap<RequestMasterData, MasterProUnit>().ReverseMap();
            CreateMap<RequestMasterData, MasterLocation>().ReverseMap();
            CreateMap<RequestMasterData, MasterDot>().ReverseMap();
            CreateMap<RequestMasterData, MasterNextService>().ReverseMap();
            CreateMap<RequestMasterData, MasterNextServiceSub>().ReverseMap();
            CreateMap<RequestMasterData, MasterCarType>().ReverseMap();
            CreateMap<RequestMasterData, MasterCarBrand>().ReverseMap();
            CreateMap<RequestMasterData, MasterCarModel>().ReverseMap();
            CreateMap<RequestMasterData, MasterCarSubModel>().ReverseMap();
            CreateMap<RequestMasterData, MasterCheckList>().ReverseMap();
            CreateMap<RequestMasterData, MasterCarGear>().ReverseMap();
            CreateMap<RequestMasterData, MasterContactType>().ReverseMap();
            CreateMap<RequestMasterData, MasterBussinessType>().ReverseMap();
            CreateMap<RequestMasterData, MasterReasonDecInc>().ReverseMap();
            CreateMap<RequestMasterData, MasterAssessment>().ReverseMap();
            CreateMap<RequestMasterData, MasterTagStatus>().ReverseMap();
            CreateMap<RequestMasterData, MasterBank>().ReverseMap();
            CreateMap<RequestMasterData, MasterCreditCard>().ReverseMap();
            CreateMap<RequestMasterData, MasterPayChqType>().ReverseMap();
            CreateMap<RequestMasterData, MasterCardUseType>().ReverseMap();
            CreateMap<RequestMasterData, MasterVatRate>().ReverseMap();
            CreateMap<RequestMasterData, MasterTaxItem>().ReverseMap();
            CreateMap<RequestMasterData, MasterPosition>().ReverseMap();
            CreateMap<Contact, VenderModel>().ReverseMap();
            CreateMap<Contact, VenderItem>().ReverseMap();
            CreateMap<Contact, CustomerModel>().ReverseMap();
            CreateMap<Contact, CustomerItem>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Product, ProductItem>().ReverseMap();
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<Car, CarItem>().ReverseMap();
            CreateMap<Sale, ReportServiceRequestItem>().ReverseMap();
            CreateMap<Sale, ReportDailySalesItem>().ReverseMap();
        }
    }
}

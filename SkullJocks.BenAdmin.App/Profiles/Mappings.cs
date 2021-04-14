using AutoMapper;
using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;
using SkullJocks.BenAdmin.Domain.Entities.Customers;

namespace SkullJocks.BenAdmin.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CustomerListVm, CustomerListModel>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeDto>().ReverseMap();
            CreateMap<CustomerDetailVm, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<CustomerTypeListVm, CustomerTypeListViewModel>().ReverseMap();
            CreateMap<CustomerTypeVm, CustomerTypeListViewModel>().ReverseMap();
            CreateMap<CreateCustomerTypeCommand, CustomerDetailVm>().ReverseMap();
            CreateMap<UpdateCustomerCommand, CustomerDetailVm>().ReverseMap();
            CreateMap<CreateCustomerCommand, CustomerDetailVm>().ReverseMap();
        }
    }
}

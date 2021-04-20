using AutoMapper;
using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;

namespace SkullJocks.BenAdmin.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CustomerListVm, CustomerListModel>().ReverseMap();
            CreateMap<CustomerDetailVm, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<CustomerTypeListVm, CustomerTypeListViewModel>().ReverseMap();
            CreateMap<CustomerTypeVm, CustomerTypeListViewModel>().ReverseMap();

            CreateMap<UpdateCustomerCommand, CustomerDetailVm>().ReverseMap();
            CreateMap<UpdateCustomerCommandResponse, CustomerDetailVm>().ReverseMap();
            CreateMap<UpdateCustomerCommand, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<UpdateCustomerCommandResponse, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<UpdateCustomerCommandViewModel, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<UpdateCustomerCommandViewModel, CustomerDetailVm>().ReverseMap();

            CreateMap<CreateCustomerCommand, CustomerDetailVm>().ReverseMap();
            CreateMap<CreateCustomerCommandResponse, CustomerDetailVm>().ReverseMap();
            CreateMap<CreateCustomerCommand, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<CreateCustomerCommandResponse, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<CreateCustomerViewModel, CustomerDetailVm>().ReverseMap();
            CreateMap<CreateCustomerViewModel, CustomerDetailsViewModel>().ReverseMap();

            CreateMap<CreateCustomerTypeCommand, CustomerDetailVm>().ReverseMap();
            CreateMap<CustomerTypeDto, CustomerTypeVm>().ReverseMap();
        }
    }
}

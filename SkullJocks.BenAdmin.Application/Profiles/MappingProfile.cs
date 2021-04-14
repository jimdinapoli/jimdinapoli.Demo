using AutoMapper;
using SkullJocks.BenAdmin.Application.Features.Addresses.Queries;
using SkullJocks.BenAdmin.Application.Features.Contacts;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer;
using SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails;
using SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType;
using SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeList;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using SkullJocks.BenAdmnin.Application.Features.Customers;

namespace SkullJocks.BenAdmnin.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListModel>().ReverseMap();
            CreateMap<Customer, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreateCustomerTypeCommand>().ReverseMap();
            CreateMap<Customer, CreateCustomerViewModel>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();

            CreateMap<CustomerType, CustomerTypeDto>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeListViewModel>().ReverseMap();
            CreateMap<Customer, CustomerTypeDto>().ReverseMap();
            CreateMap<CustomerDetailsViewModel, CustomerTypeDto>().ReverseMap();
            CreateMap<CustomerType, CreateCustomerTypeDto>().ReverseMap();

            CreateMap<Address, AddressListModel>().ReverseMap();
            CreateMap<Contact, ContactListViewModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using Blazored.LocalStorage;
using SkullJocks.BenAdmin.App.Contracts;
using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Services
{
    public class CustomerDataService : BaseService, ICustomerDataService
    {
        private readonly IMapper _mapper;
        public CustomerDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CustomerListVm>> GetAllCustomers()
        {
            var allCustomers = await _client.GetAllCustomersAsync();
            var mappedCustomers = _mapper.Map<ICollection<CustomerListVm>>(allCustomers);
            return mappedCustomers.ToList();
        }

        public async Task<CustomerDetailVm> GetCustomerById(Guid id)
        {
            var selectedCustomer = await _client.GetCustomerByIdAsync(id);
            var mappedCustomer = _mapper.Map<CustomerDetailVm>(selectedCustomer);
            //_mapper.Map(selectedCustomer.CustomerTypeDto, mappedCustomer.CutomerTypeVm);
            return mappedCustomer;
        }

        public async Task<ApiResponse<Guid>> CreateCustomer(CustomerDetailVm customerDetailViewModel)
        {
            try
            {
                CreateCustomerCommand createCustomerCommand = _mapper.Map<CreateCustomerCommand>(customerDetailViewModel);
                var newId = await _client.AddCustomerAsync(createCustomerCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateCustomer(CustomerDetailVm customerDetailViewModel)
        {
            try
            {
                UpdateCustomerCommand updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerDetailViewModel);
                await _client.UpdateCustomerAsync(updateCustomerCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }

        }
    }
}

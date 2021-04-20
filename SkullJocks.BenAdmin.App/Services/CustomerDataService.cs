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
            return mappedCustomer;
        }

        public async Task<ApiResponse<CustomerDetailVm>> CreateCustomer(CustomerDetailVm customerDetailViewModel)
        {
            try
            {
                ApiResponse<CustomerDetailVm> apiResponse = new ApiResponse<CustomerDetailVm>();
                CreateCustomerCommand createCustomerCommand = _mapper.Map<CreateCustomerCommand>(customerDetailViewModel);
                var createCustomerCommandResponse = await _client.AddCustomerAsync(createCustomerCommand);
                if (createCustomerCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CustomerDetailVm>(createCustomerCommandResponse.Customer);
                    apiResponse.Success = true;
                }

                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CustomerDetailVm>(ex);
            }
        }

        public async Task<ApiResponse<CustomerDetailVm>> UpdateCustomer(CustomerDetailVm customerDetailViewModel)
        {
            try
            {
                ApiResponse<CustomerDetailVm> apiResponse = new ApiResponse<CustomerDetailVm>();
                UpdateCustomerCommand updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerDetailViewModel);
                
                var updateCustomerCommandResponse = await _client.UpdateCustomerAsync(updateCustomerCommand);
                if (updateCustomerCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CustomerDetailVm>(updateCustomerCommandResponse.Customer);
                    apiResponse.Success = true;
                }

                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CustomerDetailVm>(ex);
            }
        }
    }
}

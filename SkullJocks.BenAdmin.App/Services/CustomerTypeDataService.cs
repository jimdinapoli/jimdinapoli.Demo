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
    public class CustomerTypeDataService : BaseService, ICustomerTypeDataService
    {
        private readonly IMapper _mapper;

        public CustomerTypeDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CustomerTypeVm>> GetAllCustomerTypes()
        {
            //await AddBearerToken();

            var allTypes = await _client.GetAllCustomerTypesAsync();
            var mappedTypes = _mapper.Map<ICollection<CustomerTypeVm>>(allTypes);
            return mappedTypes.ToList();
        }

        public async Task<ApiResponse<CreateCustomerTypeDto>> CreateCustomerType(CustomerTypeVm customerTypeViewModel)
        {
            try
            {
                ApiResponse<CreateCustomerTypeDto> apiResponse = new ApiResponse<CreateCustomerTypeDto>();
                CreateCustomerTypeCommand createCustomerTypeCommand = _mapper.Map<CreateCustomerTypeCommand>(customerTypeViewModel);
                var createCustomerTypeCommandResponse = await _client.AddCustomerTypeAsync(createCustomerTypeCommand);
                if (createCustomerTypeCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CreateCustomerTypeDto>(createCustomerTypeCommandResponse.CustomerType);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCustomerTypeCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCustomerTypeDto>(ex);
            }
        }

        public async Task<List<CustomerTypeIncludingCustomerVm>> GetAllCustomerTypesIncludingCustomers()
        {
            //await AddBearerToken();

            var allCustomerTypes = await _client.GetCustomerTypesIncludingCustomersAsync();
            var mappedCustomerTypes = _mapper.Map<ICollection<CustomerTypeIncludingCustomerVm>>(allCustomerTypes);
            return mappedCustomerTypes.ToList();
        }
    }
}

using SkullJocks.BenAdmin.App.Services;
using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Contracts
{
    public interface ICustomerTypeDataService
    {
        Task<List<CustomerTypeVm>> GetAllCustomerTypes();
        Task<List<CustomerTypeIncludingCustomerVm>> GetAllCustomerTypesIncludingCustomers();
        Task<ApiResponse<CreateCustomerTypeDto>> CreateCustomerType(CustomerTypeVm customerTypeViewModel);
    }
}

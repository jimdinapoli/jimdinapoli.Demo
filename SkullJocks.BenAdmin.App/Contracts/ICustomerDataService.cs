using SkullJocks.BenAdmin.App.Services.Base;
using SkullJocks.BenAdmin.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.Contracts
{
    public interface ICustomerDataService
    {
        Task<List<CustomerListVm>> GetAllCustomers();
        Task<CustomerDetailVm> GetCustomerById(Guid id);
        Task<ApiResponse<CustomerDetailVm>> CreateCustomer(CustomerDetailVm customerDetailViewModel);
        Task<ApiResponse<CustomerDetailVm>> UpdateCustomer(CustomerDetailVm customerDetailViewModel);
    }
}

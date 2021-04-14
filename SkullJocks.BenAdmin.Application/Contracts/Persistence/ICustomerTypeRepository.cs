using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Contracts.Persistence
{
    public interface ICustomerTypeRepository : IAsyncRepository<CustomerType>
    {
        //Task<List<CustomerType>> GetCustomerTypesIncludingCustomers();
    }
}

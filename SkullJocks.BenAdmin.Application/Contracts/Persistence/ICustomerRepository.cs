using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}

using Microsoft.EntityFrameworkCore;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Persistence.Repositories
{
    public class CustomerTypeRepository : BaseRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(BenAdminContext context) : base(context)
        {
        }

        //public async Task<List<CustomerType>> GetCustomerTypesIncludingCustomers()
        //{
        //    var types = await _context.CustomerTypes.Include(x => x.Customers).ToListAsync();
        //    return types;
        //}
    }
}

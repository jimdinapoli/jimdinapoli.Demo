using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;

namespace SkullJocks.BenAdmin.Persistence.Repositories
{
    public class CustomerRepository  : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BenAdminContext context) : base(context)
        {
        }
    }
}

using MediatR;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeListWithCustomers
{
    public class GetCustomerTypesIncludingCustomersQuery : IRequest<List<CustomerTypeWithCustomersViewModel>>
    {
    }
}

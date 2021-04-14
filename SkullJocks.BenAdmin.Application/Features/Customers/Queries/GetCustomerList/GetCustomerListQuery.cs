using MediatR;
using System.Collections.Generic;

namespace SkullJocks.BenAdmnin.Application.Features.Customers
{
    public class GetCustomerListQuery : IRequest<List<CustomerListModel>>
    {
    }
}

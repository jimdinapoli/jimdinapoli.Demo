using MediatR;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeList
{
    public class GetCustomerTypeListQuery : IRequest<List<CustomerTypeListViewModel>>
    {
    }
}

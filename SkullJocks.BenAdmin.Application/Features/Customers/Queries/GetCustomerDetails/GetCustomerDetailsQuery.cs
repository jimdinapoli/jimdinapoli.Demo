using MediatR;
using System;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetailsViewModel>
    {
        public Guid Id{ get; set; }
    }
}

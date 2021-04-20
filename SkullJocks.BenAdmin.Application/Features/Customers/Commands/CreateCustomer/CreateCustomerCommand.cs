using MediatR;
using System;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPhoneExtension { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public Guid CustomerTypeId { get; set; }
    }
}

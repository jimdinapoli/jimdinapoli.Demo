using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails
{
    public class CustomerDetailsViewModel
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
        public CustomerTypeDto CustomerType{ get; set; }
    }
}

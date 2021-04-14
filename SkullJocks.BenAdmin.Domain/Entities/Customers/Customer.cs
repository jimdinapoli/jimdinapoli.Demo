using SkullJocks.BenAdmin.Domain.Common;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using System;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Domain.Entities.Customers
{
    public class Customer : AuditEntity
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
        public ICollection<Contact> Contacts { get; set; }

    }
}

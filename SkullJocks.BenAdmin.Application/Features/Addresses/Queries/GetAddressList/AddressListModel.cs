using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using System;

namespace SkullJocks.BenAdmin.Application.Features.Addresses.Queries
{
    public class AddressListModel
    {
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public Contact Contact { get; set; }

    }
}

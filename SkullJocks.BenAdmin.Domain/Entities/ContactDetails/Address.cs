using SkullJocks.BenAdmin.Domain.Common;
using System;

namespace SkullJocks.BenAdmin.Domain.Entities.ContactDetails
{
    public class Address : AuditEntity
    {
        public Guid AddressId { get; set; }
        public Guid AddressTypeId{ get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

using SkullJocks.BenAdmin.Domain.Common;
using System;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Domain.Entities.ContactDetails
{
    public class Contact : AuditEntity
    {
        public Guid ContactId { get; set; }
        public Guid ContactTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers{ get; set; }
        public ICollection<EmailAddress> EmailAddresses{ get; set; }
    }
}

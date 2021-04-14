using System;

namespace SkullJocks.BenAdmin.Domain.Entities.ContactDetails
{
    public class PhoneNumber
    {
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberType { get; set; }
        public string Phone { get; set; }
        public string Extension { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

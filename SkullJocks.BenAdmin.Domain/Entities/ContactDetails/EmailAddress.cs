using System;

namespace SkullJocks.BenAdmin.Domain.Entities.ContactDetails
{
    public class EmailAddress
    {
        public Guid EmailAddressId{ get; set; }
        public Guid EmailAddressType { get; set; }
        public string Email { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

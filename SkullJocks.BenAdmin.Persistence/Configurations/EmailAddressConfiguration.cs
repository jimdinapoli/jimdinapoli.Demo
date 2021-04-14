using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;

namespace SkullJocks.BenAdmin.Persistence.Configurations
{
    public class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.HasKey(x => x.EmailAddressId);
        }
    }
}

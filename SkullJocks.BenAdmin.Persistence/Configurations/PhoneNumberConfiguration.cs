using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;

namespace SkullJocks.BenAdmin.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(x => x.PhoneNumberId);
        }
    }
}

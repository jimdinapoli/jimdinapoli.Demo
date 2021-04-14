using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkullJocks.BenAdmin.Domain.Entities.Customers;

namespace SkullJocks.BenAdmin.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

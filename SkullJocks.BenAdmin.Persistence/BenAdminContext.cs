using Microsoft.EntityFrameworkCore;
using SkullJocks.BenAdmin.Domain.Common;
using SkullJocks.BenAdmin.Domain.Entities;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using SkullJocks.BenAdmin.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SkullJocks.BenAdmin.Persistence
{
    public class BenAdminContext : DbContext
    {
        public BenAdminContext(DbContextOptions<BenAdminContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<EmailAddressType> EmailAddressTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BenAdminContext).Assembly);

            //var addressTypeId = Guid.NewGuid();
            //var phoneTypeId = Guid.NewGuid();
            //var emailTypeId = Guid.NewGuid();

            //modelBuilder.Entity<AddressType>().HasData(new AddressType
            //{
            //    AddressTypeId = addressTypeId,
            //    AddressTypeName = "Work Address"
            //});

            //modelBuilder.Entity<PhoneNumberType>().HasData(new PhoneNumberType
            //{
            //    PhoneNumberTypeId = phoneTypeId,
            //    PhoneType = "Work Phone"
            //});

            //modelBuilder.Entity<EmailAddressType>().HasData(new EmailAddressType
            //{
            //    EmailAddressTypeId = emailTypeId,
            //    EmailType = "Work Email"
            //});

            //var customer = new Customer
            //{
            //    CustomerName = Faker.Company.Name(),
            //    CustomerEmail = Faker.Internet.Email(),
            //    CustomerPhone = Faker.Phone.Number(),
            //    AddressLine1 = Faker.Address.StreetAddress(),
            //    City = Faker.Address.City(),
            //    State = Faker.Address.UsStateAbbr(),
            //    ZipCode = Faker.Address.ZipCode(),
            //    Country = Faker.Address.Country(),
            //    Contacts =
            //    {
            //        new Contact
            //        {
            //            FirstName = Faker.Name.First(),
            //            LastName = Faker.Name.Last(),
            //            DateOfBirth = Faker.DateOfBirth.Next(),
            //            Addresses =
            //            {
            //                new Address
            //                {
            //                    AddressTypeId = addressTypeId,
            //                    AddressLineOne = Faker.Address.StreetAddress(),
            //                    City = Faker.Address.City(),
            //                    State = Faker.Address.UsStateAbbr(),
            //                    ZipCode = Faker.Address.ZipCode(),
            //                    Country = Faker.Address.Country(),
            //                },
            //                new Address
            //                {
            //                    AddressTypeId = addressTypeId,
            //                    AddressLineOne = Faker.Address.StreetAddress(),
            //                    City = Faker.Address.City(),
            //                    State = Faker.Address.UsStateAbbr(),
            //                    ZipCode = Faker.Address.ZipCode(),
            //                    Country = Faker.Address.Country(),
            //                }
            //            },

            //            PhoneNumbers =
            //            {
            //                new PhoneNumber
            //                {
            //                    PhoneNumberType = phoneTypeId,
            //                    Phone = Faker.Phone.Number()
            //                },
            //                new PhoneNumber
            //                {
            //                    PhoneNumberType = phoneTypeId,
            //                    Phone = Faker.Phone.Number()
            //                }
            //            },

            //            EmailAddresses =
            //            {
            //                new EmailAddress
            //                {
            //                    EmailAddressId = emailTypeId,
            //                    Email = Faker.Internet.Email()
            //                },
            //                new EmailAddress
            //                {
            //                    EmailAddressId = emailTypeId,
            //                    Email = Faker.Internet.Email()
            //                }
            //            }
            //        }
            //    }
            //};
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

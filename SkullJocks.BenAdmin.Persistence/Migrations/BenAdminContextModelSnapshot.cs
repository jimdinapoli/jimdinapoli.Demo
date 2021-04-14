﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkullJocks.BenAdmin.Persistence;

namespace SkullJocks.BenAdmin.Persistence.Migrations
{
    [DbContext(typeof(BenAdminContext))]
    partial class BenAdminContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLineOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLineTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AddressTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.EmailAddress", b =>
                {
                    b.Property<Guid>("EmailAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailAddressType")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmailAddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.PhoneNumber", b =>
                {
                    b.Property<Guid>("PhoneNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PhoneNumberType")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PhoneNumberId");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhoneExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Customers.CustomerType", b =>
                {
                    b.Property<Guid>("CustomerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerTypeId");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Types.AddressType", b =>
                {
                    b.Property<Guid>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Types.ContactType", b =>
                {
                    b.Property<Guid>("ContactTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactTypeId");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Types.EmailAddressType", b =>
                {
                    b.Property<Guid>("EmailAddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailAddressTypeId");

                    b.ToTable("EmailAddressTypes");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Address", b =>
                {
                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.Customers.Customer", null)
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", b =>
                {
                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.Customers.Customer", null)
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.EmailAddress", b =>
                {
                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", "Contact")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.PhoneNumber", b =>
                {
                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Customers.Customer", b =>
                {
                    b.HasOne("SkullJocks.BenAdmin.Domain.Entities.Customers.CustomerType", null)
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.ContactDetails.Contact", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("EmailAddresses");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("SkullJocks.BenAdmin.Domain.Entities.Customers.CustomerType", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
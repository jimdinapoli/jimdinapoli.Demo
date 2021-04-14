using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkullJocks.BenAdmin.Persistence.Migrations
{
    public partial class Ititial_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailAddress",
                table: "EmailAddress");

            migrationBuilder.RenameTable(
                name: "EmailAddress",
                newName: "EmailAddresses");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailAddresses",
                table: "EmailAddresses",
                column: "EmailAddressId");

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    ContactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.ContactTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddressTypes",
                columns: table => new
                {
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddressTypes", x => x.EmailAddressTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_ContactId",
                table: "PhoneNumber",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_ContactId",
                table: "EmailAddresses",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                table: "Addresses",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_Contacts_ContactId",
                table: "EmailAddresses",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Contacts_ContactId",
                table: "PhoneNumber",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_Contacts_ContactId",
                table: "EmailAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Contacts_ContactId",
                table: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "EmailAddressTypes");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumber_ContactId",
                table: "PhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailAddresses",
                table: "EmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_ContactId",
                table: "EmailAddresses");

            migrationBuilder.RenameTable(
                name: "EmailAddresses",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Addresses",
                newName: "Zip");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailAddress",
                table: "EmailAddress",
                column: "EmailAddressId");
        }
    }
}

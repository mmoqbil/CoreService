using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class AddnewcolumnCreationDatetoResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66bca272-bb27-4d23-8dd4-9efab8cb29e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ae05d0c-0ded-4a2a-891b-03cce32ee722");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cf6a4c-37ee-4db7-96a8-9c722f98f847");

            migrationBuilder.RenameColumn(
                name: "Refreshing",
                table: "Resources",
                newName: "Refresh");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Resources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ff2f7968-08a3-403d-a771-2708f3c2dd9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d0b9a3cb-91af-44ef-abf3-cf684d07da07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ec28f510-10a8-41f9-8297-c59f307a578f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "31ce2b7a-62db-49ec-9e51-7852f45c9698", 0, "3a51fbc6-67a7-4c5b-bd1d-4a2a97876123", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEDcSx8y6dkMsdG4QmflU5k2J+aGYHq8+bElgRj7M2UbN6n/xwoCuzJMj46ZMo0Eumg==", null, false, "13554d2f-e4e4-4db4-b209-686ec26e3a1f", false, "johndoe" },
                    { "467ea9ff-117a-4114-81aa-b1a667074b4a", 0, "8f68192a-8aa8-440e-af87-8974d5a1810f", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOshFRzVqjeUziv4R05lp29zmqD6pUBTIRqPZvUwnPRP3KTm30xHLMXiprd2dKt2Hw==", null, false, "b813c6ed-293b-4954-88fd-8d928eeab972", false, "Judasz" },
                    { "e58f9bcd-91d1-4768-99cd-f737c7428213", 0, "f71eb985-7749-4c40-926b-2f3f07cf6caf", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMbEP3OV96rt3vUggVOiZlWCmzSkvCghNL6x70CS/TJqbMAk47+FyZzJn5of5lYEBg==", null, false, "997979e3-5a47-43eb-8065-2fd90e8ae891", false, "Adam" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31ce2b7a-62db-49ec-9e51-7852f45c9698");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "467ea9ff-117a-4114-81aa-b1a667074b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e58f9bcd-91d1-4768-99cd-f737c7428213");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "Refresh",
                table: "Resources",
                newName: "Refreshing");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ceeeb4c0-6a61-45d2-a537-5780645fc802");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "78527f55-3707-4f3a-8bf9-d8cf6cfb4be3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "1a705198-aaf0-4b64-a4fd-53121b705714");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "66bca272-bb27-4d23-8dd4-9efab8cb29e3", 0, "8eaee34a-2f81-4d1d-9356-faf08acc1b27", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEEZq/2YdKYfPjdTiOhWommCvf3chJ5wreEvGU/+H5/KmmESfvtrvcTZPW1D9Gr4/xg==", null, false, "93922672-baf4-44be-ab6d-140c047cc701", false, "Adam" },
                    { "8ae05d0c-0ded-4a2a-891b-03cce32ee722", 0, "93acf820-77f3-49cb-a61a-8a0b3a086af5", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJXccg7LyawKOKc0+0aUnebDAfASjazA+CdXGi3NUU2+LXzH3mfK7P/b+Ul80UBeag==", null, false, "7cd4f30b-ebeb-4d3a-8042-3d22b1397c7d", false, "Judasz" },
                    { "f0cf6a4c-37ee-4db7-96a8-9c722f98f847", 0, "fd464ef8-d816-494c-8ce7-816532582093", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPL8Umgq7ky9QPlORBiKx7Rc6+dR2YaktquBIsslLSmHCiM8jANS7fd7rK8It8SCUA==", null, false, "b619c23e-bba0-4ea6-a4b1-e55538536d2e", false, "johndoe" }
                });
        }
    }
}

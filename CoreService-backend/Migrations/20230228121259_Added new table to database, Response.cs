using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class AddednewtabletodatabaseResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60d7ab64-367b-4f35-908a-bacf504d1101");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38eab76-7608-499b-a518-55c604b2db60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7489b98-0fb5-4c6e-ab8c-3f4f88773823");

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ping = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c1c9e309-3a47-40f8-b6a1-8f938739455a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2c66d17a-cf35-496e-9ac3-a5d15fb76622");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "36e3e81d-a3eb-4032-ad8c-5eeecdb5ba82");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "60d7ab64-367b-4f35-908a-bacf504d1101", 0, "fc05559a-687d-4ef9-b54a-f800c6e26877", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAJyc40Ha1W86OdbbPSOeW364hAXd43/57Wg2yROmqIu4xpAfqq/+mWysOCtmlvP0Q==", null, false, "9e70cd8d-9a8e-4ea6-906a-e12f52b3202c", false, "johndoe" },
                    { "a38eab76-7608-499b-a518-55c604b2db60", 0, "40ab1d18-5fee-48eb-8671-aaef4608c7c4", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEDSyIaR+wqevpdvaAWW1x1C2/nDHY6QGOky3mEjkk0IrI/9wSadVX+YE883pYSzXnw==", null, false, "dbf5de88-77a8-499c-9600-d39dda3e8335", false, "Judasz" },
                    { "e7489b98-0fb5-4c6e-ab8c-3f4f88773823", 0, "2d0d3c65-6fed-4f4d-bc55-6f3d8b205d01", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGT1zdA98lz2zzTbsKlKicU2K2GIin+Y01/7HsG57fB/P+e2eatXNFWBdvWaxyN4mA==", null, false, "fe9b54ac-76a6-4dee-b53d-aea197552c8a", false, "Adam" }
                });
        }
    }
}

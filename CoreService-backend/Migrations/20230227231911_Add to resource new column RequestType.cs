using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class AddtoresourcenewcolumnRequestType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "019fb97a-a78c-40ef-8de6-da21236d9ef5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6236f412-6269-4102-865d-bb37615c1ea5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea53bafc-7a9f-4f6e-ad3a-785421aec8a4");

            migrationBuilder.RenameColumn(
                name: "Repeat",
                table: "Resources",
                newName: "Refreshing");

            migrationBuilder.AddColumn<int>(
                name: "RequestType",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "Refreshing",
                table: "Resources",
                newName: "Repeat");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "98743ab6-50de-4347-a09c-aa0a564f35de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5a024225-f795-449a-90bc-0956a67dd6ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "027c9136-248f-4810-8446-ad2cbe53e0a4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "019fb97a-a78c-40ef-8de6-da21236d9ef5", 0, "4d06bc98-c873-4fa5-8715-c69742cc41ff", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENadgo6midNRXKOYnSOT8bf0m3lvRK3oI57h3Fw9vAVujPQeqbeu9J2gV/lJWaPCpA==", null, false, "dd997ba8-8dca-472e-ac55-ecee47244c86", false, "Judasz" },
                    { "6236f412-6269-4102-865d-bb37615c1ea5", 0, "a0221793-99b3-4210-b42a-98d69b246c37", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOXf2/t4BYR07SA/0BbJLehwQAPLJ5JPxOZRLLuOhLCQu6h8Gq7wZR+AeS16jsGTVA==", null, false, "1668f851-566b-400a-afe1-d6509b44c956", false, "johndoe" },
                    { "ea53bafc-7a9f-4f6e-ad3a-785421aec8a4", 0, "fe6a15e0-cb36-45a2-8141-a361d03c51c4", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBVtQLGsTrYIaTrnTuuxOny0l39wl2vZ8WubdUjS+gLWNqPV1VYUBovli7IfNuGX1g==", null, false, "478ca37c-923d-42ae-a184-a54eb2908220", false, "Adam" }
                });
        }
    }
}

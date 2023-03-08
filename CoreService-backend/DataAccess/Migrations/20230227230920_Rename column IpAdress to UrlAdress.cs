using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class RenamecolumnIpAdresstoUrlAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25113f09-a179-4da2-912f-14d067b9e26e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7755a8cc-cf32-4eed-b5c5-e517c1d3f7f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbfe92d2-11f2-43e5-a11b-face097bd67a");

            migrationBuilder.RenameColumn(
                name: "IpAdress",
                table: "Resources",
                newName: "UrlAdress");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UrlAdress",
                table: "Resources",
                newName: "IpAdress");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4cbf76e9-e7b3-497e-a100-fddd1923b97a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "91bfc23e-9fe2-4b03-8854-6a2781b85b3e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d99c9089-2633-41af-8ccc-ebfabe61cef6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "25113f09-a179-4da2-912f-14d067b9e26e", 0, "426f6f3c-ed78-457d-bf04-b9dfcb406dc5", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPxsnrz1E1mPKMKNIs0L3c1LaXZ/fSiVsiIBtkAR0u9ey2PImF+waSXWTLglgiBTJQ==", null, false, "1bd85f71-aa02-43cd-b6f2-6da80ba2fe64", false, "Judasz" },
                    { "7755a8cc-cf32-4eed-b5c5-e517c1d3f7f4", 0, "81a4689a-6659-4735-aa78-9ca8ac9bbdda", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJ6dC5pppL2xGssQVupGP1TuosGNMfq3n39pmYeC1xM7KsNrVhxDsGWHFYUgro7pAA==", null, false, "a454993f-c282-47f0-8e09-38ce2f1a0a34", false, "johndoe" },
                    { "bbfe92d2-11f2-43e5-a11b-face097bd67a", 0, "d77542b1-186d-469a-914d-44259d55a7f9", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPllPeLsdpeuJV2bdBw2kSXdWthr0la6VXOW4qaXDM5ZblrVjBHGn5UaNiuyc0pTXQ==", null, false, "fd3848d6-5189-4827-b5e9-fe536151a125", false, "Adam" }
                });
        }
    }
}

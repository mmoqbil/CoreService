using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8a4d2a-b929-448f-97e8-572d1e9ce2d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "648d91c7-8607-43ff-b61a-e7c0dbab83c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87492aa7-31bd-4bd6-a88f-a742d87c1dde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fe19e682-96d4-4ac2-8879-e9a396ab8b68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0ca8c31a-0f77-499f-b542-f22abc7496a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f42b8f28-9c64-41aa-bec1-bcfa52598d3e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "130a73f8-0202-4de8-98e3-7d0f9a5d2244", 0, "7101652b-7270-4514-9dfa-fdb66def6da0", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBwS9TUxP8N0G03fuyX6eUoyUuTuxU2Veq4+HSaO1bdYMkKgGGBg2acXPWZxOySWAQ==", null, false, "a99a9bcf-156b-43dc-892b-83275d5d9050", false, "Adam" },
                    { "5d1ee01c-8327-445b-bd36-4010dc3241c4", 0, "1963c87d-29c0-407e-adb7-ef660550e178", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKUL/k/IpMn6PrBgbx+bUL3maPN6MXoWDRRAr8OzrkwvamtlS+0GadcHgefiwyRXRw==", null, false, "5103b72b-a227-45e5-ae3c-cec835aa4593", false, "Judasz" },
                    { "f51ada9c-3613-48fe-8990-928ebff5ef30", 0, "ad35530a-78a5-4cbd-a4dd-08026f9dc4ba", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEN51SXDe7tGdY6Lb2WLjkkZm6mbsvqL6iUwe/ocKlx6D0W8WHVkOZGLQuA8f3vtGWQ==", null, false, "79f73383-7dc4-4918-8011-962f5f9fa502", false, "johndoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "130a73f8-0202-4de8-98e3-7d0f9a5d2244");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d1ee01c-8327-445b-bd36-4010dc3241c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f51ada9c-3613-48fe-8990-928ebff5ef30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "14118e9f-ffdd-46cc-bc16-8e10cc785991");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "cc8bcf51-7a24-47d8-8c9c-d6d5ad98a788");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d7ae1e8a-92b0-4c32-a3a1-90406d9b02de");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5e8a4d2a-b929-448f-97e8-572d1e9ce2d4", 0, "d76d63fe-868e-4da7-846f-edf49004fd3e", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENtsjLSQwlMzB8nb2Vsvj1uunQlSONofbQlukC9ma2bvbMW0DvG7mL+G8Xsn/y1egQ==", null, false, "9fdcb622-107d-4378-a0b4-8b282a37b9c1", false, "johndoe" },
                    { "648d91c7-8607-43ff-b61a-e7c0dbab83c3", 0, "8d93e184-821a-4632-a27d-86c302736169", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGJwPzr2AWsp4frN7mFTvxKM0Y7THw+n2Ue3mIjs6Lb/4csz8Ao/MfJWNEU64jYcPQ==", null, false, "1a3ea885-4888-4964-aeb2-c7427d73dcaa", false, "Judasz" },
                    { "87492aa7-31bd-4bd6-a88f-a742d87c1dde", 0, "b3a1f911-2e8d-4481-9689-f63e8298592f", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEG2Igaxoh5npjdLEitGYBnD0MclMh8fKX2baemYGWQsGReHIOL3CV3frM2ZIwA0Tzw==", null, false, "bda0686a-88b4-4e2c-ad75-5107da0e2be6", false, "Adam" }
                });
        }
    }
}

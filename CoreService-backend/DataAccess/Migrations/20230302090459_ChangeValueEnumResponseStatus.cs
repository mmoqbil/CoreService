using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValueEnumResponseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6abcc56f-994e-48ed-b1b3-c6ec5440703b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4b8b4d0-47c8-4806-ae32-815f859ce7bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c326c5f7-1e47-4057-b6d3-fd324dc9f307");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "95e5a5be-5b35-4c94-9a84-aff9c92a97d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2ee73c5d-9bc9-4e1f-9a60-25c20d87f899");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "76970b69-e8c2-4d08-93be-4c32aa6cca7f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6abcc56f-994e-48ed-b1b3-c6ec5440703b", 0, "922ec0bd-e827-4002-9c8e-53c960186713", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMRdkQOIx/8XkFGo+LoznG25z6qlra40BagbfWezRxgPgv/MPRfecpD8txNzb/jgVQ==", null, false, "6ae6b1c7-afea-4e40-84d0-d3c83c4a6fcf", false, "Judasz" },
                    { "b4b8b4d0-47c8-4806-ae32-815f859ce7bb", 0, "e06ab526-7dbb-4045-931a-2f637ff0469b", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOAjBFaW3hk0q45AcCYa2eUMTgkbGGmitxP5468kZhwZavkdU2uh0ZOFFGNTl53skw==", null, false, "3ce91439-a070-47f1-9216-77cc6991b5b3", false, "johndoe" },
                    { "c326c5f7-1e47-4057-b6d3-fd324dc9f307", 0, "980e9b84-323c-4f07-aea1-eb3b24cd3683", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEDGUVd1nPcOZGxzYD3Ik1G5p1xVFBzRArD6Mr8aotKK6cDAPkJqZOxO9LLLMubsdQw==", null, false, "a8b3bc1f-20cd-423c-9b85-1855098dafef", false, "Adam" }
                });
        }
    }
}

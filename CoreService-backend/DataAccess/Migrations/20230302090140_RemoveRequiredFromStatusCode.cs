using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredFromStatusCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "795668a8-86a6-4b60-ab54-9c7d0421b709");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0dbb824-4334-4bc8-a413-a0bd67b16d5c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed0dc3e1-f1d2-4362-80f7-aaa8d2ca9a8e");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "Response",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cd1cad56-ce28-4ef0-9938-4fa8f5005a69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "72553808-e4c3-4e80-bea0-06c84a701cab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "61882856-fcdd-4a29-9525-1c19da39d271");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "795668a8-86a6-4b60-ab54-9c7d0421b709", 0, "6ded813e-04bc-4fbf-97f8-d41a22adf1d3", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAf5/9uy/TnTn9AqqEnQ1ks9Cwp2hXLjP/TXkIJAiX8sHLyXV0bPylI6qCW3zciJRA==", null, false, "d59ae1e7-b1cc-409a-b1f3-935a566c0f8f", false, "Judasz" },
                    { "c0dbb824-4334-4bc8-a413-a0bd67b16d5c", 0, "4cb51958-5de2-4daa-a732-542e5f94420c", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEN+QlerKjV0mIQXy7Np4dwl3n5PX8P6E1lXaiTy22suQxSTgk5/RQcnGbRBIv1JY6w==", null, false, "9f8e8a64-e821-4a6d-bcc9-64afd2956b8f", false, "Adam" },
                    { "ed0dc3e1-f1d2-4362-80f7-aaa8d2ca9a8e", 0, "fcc14665-9bc9-4319-b9af-7d631107cf90", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECJjROxgMt+PJ+Gvm/JAjsy1GHadezyyaMWVyEMGJYnQ9806Rpo86m7+oXGdY92Csg==", null, false, "edef7571-8123-43d4-8f89-fc96c4991e95", false, "johndoe" }
                });
        }
    }
}

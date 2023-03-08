using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddnewtableRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Invalidated = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4ff05437-6444-4b78-88e6-20e4d4cdcd40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6a314a6d-a269-4dbf-83b4-da821c617af5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "de5b4127-df92-4c36-b81c-2f059eb9292f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ed2ba3a-4fb0-4ae2-b0d4-dd055fb4c179", 0, "c404ff08-2cd0-417f-b4f3-77257ec6038f", "johndoe@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEE6g7R8u3nNZDbHxIuNGs2mFLDzL8I4vaexFGmIUJmgDYk3Z6G7wdySV2lmjQ0f6Uw==", null, false, "2f4d9735-e073-4079-b8d1-1b6aa9009fa1", false, "johndoe" },
                    { "576e2bc2-1417-49d2-b9ec-0596c6bbcc3b", 0, "e9c5a11a-8182-4098-981c-d7a144df5bbf", "adam@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHAVQk9R3NpHQcmqAJdFiEgqfj4FLg2/vtzmicNrjRKeySpqr4i/FB2E/kHAyJ5gRQ==", null, false, "b2e05e00-0e2e-4c2a-b454-ea8da9700289", false, "Adam" },
                    { "c9d9e901-2dd5-4c5b-b7ce-a85f44cf6aa9", 0, "1b920588-4d22-43f9-af13-a92b520aa121", "judasz@example.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPoafJNprPVrtwPhVoT1fuKMo5yIuaRfKP09QPtTGdGJuYUH752+In9AXeQqd2ru/Q==", null, false, "a4efa160-ab2b-42fc-8ca5-ee78cb7bbb22", false, "Judasz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ed2ba3a-4fb0-4ae2-b0d4-dd055fb4c179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "576e2bc2-1417-49d2-b9ec-0596c6bbcc3b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9d9e901-2dd5-4c5b-b7ce-a85f44cf6aa9");

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
    }
}

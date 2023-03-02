using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ResponseStatus",
                table: "Response",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Ping",
                table: "Response",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "Response",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Response");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseStatus",
                table: "Response",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Ping",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "Response",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
    }
}

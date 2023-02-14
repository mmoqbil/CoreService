using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreServicebackend.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "IpAdress", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "127.0.0.1", "LocalHost", 1 },
                    { 2, "187.166.70.216", "My private website", 1 },
                    { 3, "40.214.147.21", "Some adress", 2 },
                    { 4, "26.252.235.19", "My email service", 3 },
                    { 5, "127.0.0.1", "Shop website", 3 },
                    { 6, "175.189.43.59", "Coffee website", 3 },
                    { 7, "148.143.234.67", "My car rent website", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "example@email.org", "Antony", "Example1" },
                    { 2, "example2@gmail.org", "Adam", "Example2" },
                    { 3, "example3@gmail.org", "Maciej", "Example3" },
                    { 4, "example4@gmail.org", "Ryszard", "Example4" },
                    { 5, "example5@gmail.org", "Piotr", "Example5" },
                    { 6, "example6@gmail.org", "Natalia", "Example6" },
                    { 7, "example6@gmail.org", "Karolina", "Example6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositoryy.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baking" },
                    { 2, "Cleaning" },
                    { 3, "Teaching" },
                    { 4, "Gardening" },
                    { 5, "Coding" }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "SkillId" },
                values: new object[,]
                {
                    { 1, null, "yael@example.com", "Yael", "Gutman", "pass1", null, "user", 1 },
                    { 2, null, "yehudit@example.com", "Yehudit", "Vaiss", "pass2", null, "user", 2 },
                    { 3, null, "noa@example.com", "Noa", "Levi", "pass3", null, "user", 3 },
                    { 4, null, "michal@example.com", "Michal", "Cohen", "pass4", null, "admin", 1 },
                    { 5, null, "tamar@example.com", "Tamar", "Aharoni", "pass5", null, "user", 4 },
                    { 6, null, "rivka@example.com", "Rivka", "Shwartz", "pass6", null, "user", 5 },
                    { 7, null, "sarah@example.com", "Sarah", "Gold", "pass7", null, "user", 2 },
                    { 8, null, "esther@example.com", "Esther", "Katz", "pass8", null, "user", 3 },
                    { 9, null, "avigail@example.com", "Avigail", "Friedman", "pass9", null, "user", 4 },
                    { 10, null, "leah@example.com", "Leah", "Stern", "pass10", null, "user", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

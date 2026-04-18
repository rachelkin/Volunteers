using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositoryy.Migrations
{
    /// <inheritdoc />
    public partial class FinalManyToManyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Skills_SkillId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_SkillId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Volunteers");

            migrationBuilder.CreateTable(
                name: "MyVolunteerSkill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    VolunteersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyVolunteerSkill", x => new { x.SkillsId, x.VolunteersId });
                    table.ForeignKey(
                        name: "FK_MyVolunteerSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyVolunteerSkill_Volunteers_VolunteersId",
                        column: x => x.VolunteersId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MyVolunteerSkill",
                columns: new[] { "SkillsId", "VolunteersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 2, 7 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 8 },
                    { 4, 5 },
                    { 4, 9 },
                    { 5, 6 },
                    { 5, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1995, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "050-1234561" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1998, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "052-1234562" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "054-1234563" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1990, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "053-1234564" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1997, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "058-1234565" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "050-1234566" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1996, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "052-1234567" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1993, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "054-1234568" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1999, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "053-1234569" });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "PhoneNumber" },
                values: new object[] { new DateTime(1991, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "058-1234560" });

            migrationBuilder.CreateIndex(
                name: "IX_MyVolunteerSkill_VolunteersId",
                table: "MyVolunteerSkill",
                column: "VolunteersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyVolunteerSkill");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Volunteers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 2 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 3 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 4 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 5 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 2 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 3 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 4 });

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "PhoneNumber", "SkillId" },
                values: new object[] { null, null, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_SkillId",
                table: "Volunteers",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Skills_SkillId",
                table: "Volunteers",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("0d7ca956-c1c5-4c96-939d-5740ce489714"));

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "grades");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("217d96bb-cdbc-44e7-ac40-5b6ff97a7d40"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("217d96bb-cdbc-44e7-ac40-5b6ff97a7d40"));

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("0d7ca956-c1c5-4c96-939d-5740ce489714"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }
    }
}

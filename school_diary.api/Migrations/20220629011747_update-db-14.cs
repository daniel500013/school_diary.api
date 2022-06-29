using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("44a04bee-ef78-467c-b6c3-e32110e9cdc8"));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("f1ea482c-d5c3-4beb-997f-25dd9794959d"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("f1ea482c-d5c3-4beb-997f-25dd9794959d"));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("44a04bee-ef78-467c-b6c3-e32110e9cdc8"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }
    }
}

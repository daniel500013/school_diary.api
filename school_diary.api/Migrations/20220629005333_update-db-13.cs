using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("beda6bbc-3953-4cb8-91d1-019f8627111b"));

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "grades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserClassId",
                table: "grades",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("44a04bee-ef78-467c-b6c3-e32110e9cdc8"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_grades_UserClassId",
                table: "grades",
                column: "UserClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_grades_userClass_UserClassId",
                table: "grades",
                column: "UserClassId",
                principalTable: "userClass",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grades_userClass_UserClassId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_UserClassId",
                table: "grades");

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("44a04bee-ef78-467c-b6c3-e32110e9cdc8"));

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "grades");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("beda6bbc-3953-4cb8-91d1-019f8627111b"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }
    }
}

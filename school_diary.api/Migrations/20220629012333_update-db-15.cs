using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("f1ea482c-d5c3-4beb-997f-25dd9794959d"));

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "grades");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("bfce7a96-0911-46a2-a719-5e73fef0719b"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("bfce7a96-0911-46a2-a719-5e73fef0719b"));

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserClassId",
                table: "grades",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("f1ea482c-d5c3-4beb-997f-25dd9794959d"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });

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
    }
}

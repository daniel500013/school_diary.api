using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "RoleId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "userClassId", "zipCode" },
                values: new object[] { new Guid("beda6bbc-3953-4cb8-91d1-019f8627111b"), 5, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("beda6bbc-3953-4cb8-91d1-019f8627111b"));
        }
    }
}

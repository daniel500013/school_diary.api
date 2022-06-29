using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Tutor");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "LocalAdmin");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Admin" });

            migrationBuilder.InsertData(
                table: "userClass",
                columns: new[] { "Id", "userClass", "userClassProfile" },
                values: new object[] { 1, 1, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "userClass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "LocalAdmin");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Admin");
        }
    }
}

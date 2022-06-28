using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Positive",
                table: "approves",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Positive",
                table: "approves");
        }
    }
}

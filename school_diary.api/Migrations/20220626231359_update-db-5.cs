using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lesson_GradeId",
                table: "lesson",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_lesson_grades_GradeId",
                table: "lesson",
                column: "GradeId",
                principalTable: "grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesson_grades_GradeId",
                table: "lesson");

            migrationBuilder.DropIndex(
                name: "IX_lesson_GradeId",
                table: "lesson");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "lesson");
        }
    }
}

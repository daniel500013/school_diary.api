using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_marks_LessonId",
                table: "marks",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_lesson_LessonId",
                table: "marks",
                column: "LessonId",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_lesson_LessonId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_LessonId",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "marks");
        }
    }
}

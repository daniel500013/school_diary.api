using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_grades_LessonId",
                table: "grades",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_grades_lesson_LessonId",
                table: "grades",
                column: "LessonId",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grades_lesson_LessonId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_LessonId",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "grades");

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
    }
}

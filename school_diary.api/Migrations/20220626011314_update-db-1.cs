using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_lesson_LessonID",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_LessonID",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "LessonID",
                table: "marks");

            migrationBuilder.AlterColumn<string>(
                name: "userClassProfile",
                table: "userClass",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_LessonId",
                table: "user",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_lesson_LessonId",
                table: "user",
                column: "LessonId",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_lesson_LessonId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_LessonId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "userClassProfile",
                table: "userClass",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonID",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_marks_LessonID",
                table: "marks",
                column: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_lesson_LessonID",
                table: "marks",
                column: "LessonID",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_user_UserID",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_user_lesson_LessonId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_LessonId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_marks_UserID",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "marks");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "lesson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_lesson_UserId",
                table: "lesson",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_lesson_user_UserId",
                table: "lesson",
                column: "UserId",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesson_user_UserId",
                table: "lesson");

            migrationBuilder.DropIndex(
                name: "IX_lesson_UserId",
                table: "lesson");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "lesson");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "marks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_user_LessonId",
                table: "user",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_marks_UserID",
                table: "marks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_user_UserID",
                table: "marks",
                column: "UserID",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_lesson_LessonId",
                table: "user",
                column: "LessonId",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

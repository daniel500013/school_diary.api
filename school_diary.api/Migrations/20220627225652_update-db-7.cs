using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "approves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approves_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approves_LessonId",
                table: "approves",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approves");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "userClass",
                columns: table => new
                {
                    userclassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userClass = table.Column<int>(type: "int", nullable: false),
                    userClassProfile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userClass", x => x.userclassID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_RoleId = table.Column<int>(type: "int", nullable: false),
                    FK_userClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userUUID);
                    table.ForeignKey(
                        name: "FK_user_role_FK_RoleId",
                        column: x => x.FK_RoleId,
                        principalTable: "role",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_userClass_FK_userClassId",
                        column: x => x.FK_userClassId,
                        principalTable: "userClass",
                        principalColumn: "userclassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    lessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_UserUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.lessonID);
                    table.ForeignKey(
                        name: "FK_lesson_user_FK_UserUUID",
                        column: x => x.FK_UserUUID,
                        principalTable: "user",
                        principalColumn: "userUUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approves",
                columns: table => new
                {
                    approveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Positive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approves", x => x.approveID);
                    table.ForeignKey(
                        name: "FK_approves_lesson_FK_LessonId",
                        column: x => x.FK_LessonId,
                        principalTable: "lesson",
                        principalColumn: "lessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    gradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.gradeID);
                    table.ForeignKey(
                        name: "FK_grades_lesson_FK_LessonId",
                        column: x => x.FK_LessonId,
                        principalTable: "lesson",
                        principalColumn: "lessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    marksID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Present = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.marksID);
                    table.ForeignKey(
                        name: "FK_marks_lesson_FK_LessonId",
                        column: x => x.FK_LessonId,
                        principalTable: "lesson",
                        principalColumn: "lessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "roleID", "Name" },
                values: new object[,]
                {
                    { 1, "Student" },
                    { 2, "Teacher" },
                    { 3, "Tutor" },
                    { 4, "LocalAdmin" },
                    { 5, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "userClass",
                columns: new[] { "userclassID", "userClass", "userClassProfile" },
                values: new object[] { 1, 1, "" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userUUID", "FK_RoleId", "FK_userClassId", "address", "city", "email", "firstName", "hashPassword", "lastName", "password", "phone", "state", "zipCode" },
                values: new object[] { new Guid("f72a1cac-7bd8-4d46-9bb0-34e136d6336d"), 5, 1, null, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==", null, "", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_approves_FK_LessonId",
                table: "approves",
                column: "FK_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_FK_LessonId",
                table: "grades",
                column: "FK_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_FK_UserUUID",
                table: "lesson",
                column: "FK_UserUUID");

            migrationBuilder.CreateIndex(
                name: "IX_marks_FK_LessonId",
                table: "marks",
                column: "FK_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_FK_RoleId",
                table: "user",
                column: "FK_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_FK_userClassId",
                table: "user",
                column: "FK_userClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approves");

            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "userClass");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_diary.api.Migrations
{
    public partial class updatedb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "approves",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_approves_UserId",
                table: "approves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_approves_user_UserId",
                table: "approves",
                column: "UserId",
                principalTable: "user",
                principalColumn: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approves_user_UserId",
                table: "approves");

            migrationBuilder.DropIndex(
                name: "IX_approves_UserId",
                table: "approves");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "approves");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Chatter.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Blog_BlogIdId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BlogIdId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BlogIdId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserIdId",
                table: "Blog",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_UserIdId",
                table: "Blog",
                column: "UserIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_UserIdId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UserIdId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "BlogIdId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_BlogIdId",
                table: "User",
                column: "BlogIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Blog_BlogIdId",
                table: "User",
                column: "BlogIdId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

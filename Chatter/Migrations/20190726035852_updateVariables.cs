using Microsoft.EntityFrameworkCore.Migrations;

namespace Chatter.Migrations
{
    public partial class updateVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Board_BoardIdId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_UserIdId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Blog",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BoardIdId",
                table: "Blog",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_UserIdId",
                table: "Blog",
                newName: "IX_Blog_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_BoardIdId",
                table: "Blog",
                newName: "IX_Blog_BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Board_BoardId",
                table: "Blog",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_UserId",
                table: "Blog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Board_BoardId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_UserId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Blog",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Blog",
                newName: "BoardIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                newName: "IX_Blog_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_BoardId",
                table: "Blog",
                newName: "IX_Blog_BoardIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Board_BoardIdId",
                table: "Blog",
                column: "BoardIdId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_UserIdId",
                table: "Blog",
                column: "UserIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

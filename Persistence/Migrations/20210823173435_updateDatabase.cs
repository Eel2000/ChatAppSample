using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Messages",
                newName: "UserPhone");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                newName: "IX_Messages_UserPhone");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserPhone",
                table: "Messages",
                column: "UserPhone",
                principalTable: "Users",
                principalColumn: "Phone",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserPhone",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "Messages",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserPhone",
                table: "Messages",
                newName: "IX_Messages_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Phone",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

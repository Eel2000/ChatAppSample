using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderPhone",
                table: "Messages",
                newName: "ReceiverPhone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverPhone",
                table: "Messages",
                newName: "SenderPhone");

            migrationBuilder.AddColumn<string>(
                name: "SenderID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

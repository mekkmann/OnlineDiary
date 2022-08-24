using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDiary_Database_Api.Migrations
{
    public partial class AddedUserIdToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Book");
        }
    }
}

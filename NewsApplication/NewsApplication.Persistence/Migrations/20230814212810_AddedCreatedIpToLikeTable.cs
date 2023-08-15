using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApplication.Persistence.Migrations
{
    public partial class AddedCreatedIpToLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Likes");
        }
    }
}

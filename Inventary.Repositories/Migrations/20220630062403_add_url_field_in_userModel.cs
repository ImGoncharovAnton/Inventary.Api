using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class add_url_field_in_userModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlCrop",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "urlOrig",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlCrop",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "urlOrig",
                table: "Users");
        }
    }
}

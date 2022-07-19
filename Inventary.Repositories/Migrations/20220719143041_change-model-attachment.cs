using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class changemodelattachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrigUrl",
                table: "Attachments",
                newName: "FileUrl");

            migrationBuilder.RenameColumn(
                name: "AttachmentName",
                table: "Attachments",
                newName: "FileType");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Attachments",
                newName: "OrigUrl");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Attachments",
                newName: "AttachmentName");
        }
    }
}

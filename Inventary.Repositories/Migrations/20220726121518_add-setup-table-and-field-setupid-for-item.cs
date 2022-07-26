using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addsetuptableandfieldsetupidforitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SetupId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SetupId",
                table: "Items",
                column: "SetupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items",
                column: "SetupId",
                principalTable: "Setups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropIndex(
                name: "IX_Items_SetupId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SetupId",
                table: "Items");
        }
    }
}

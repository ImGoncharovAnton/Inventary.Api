using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class remove_category_items_setups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Setups_SetupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SetupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SetupId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SetupId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_SetupId",
                table: "Users",
                column: "SetupId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Setups_SetupId",
                table: "Users",
                column: "SetupId",
                principalTable: "Setups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

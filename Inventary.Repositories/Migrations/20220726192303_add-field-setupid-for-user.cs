using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addfieldsetupidforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentSetupId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentSetupId",
                table: "Users",
                column: "CurrentSetupId",
                unique: true,
                filter: "[CurrentSetupId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Setups_CurrentSetupId",
                table: "Users",
                column: "CurrentSetupId",
                principalTable: "Setups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Setups_CurrentSetupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrentSetupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentSetupId",
                table: "Users");
        }
    }
}

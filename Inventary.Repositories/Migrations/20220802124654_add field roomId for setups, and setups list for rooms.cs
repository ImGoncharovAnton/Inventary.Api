using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addfieldroomIdforsetupsandsetupslistforrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Setups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Setups_RoomId",
                table: "Setups",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Setups_Rooms_RoomId",
                table: "Setups",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setups_Rooms_RoomId",
                table: "Setups");

            migrationBuilder.DropIndex(
                name: "IX_Setups_RoomId",
                table: "Setups");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Setups");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addnullablefieldsetupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items",
                column: "SetupId",
                principalTable: "Setups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Setups_SetupId",
                table: "Items",
                column: "SetupId",
                principalTable: "Setups",
                principalColumn: "Id");
        }
    }
}

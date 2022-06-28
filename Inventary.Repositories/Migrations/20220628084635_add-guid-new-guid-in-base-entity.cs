using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addguidnewguidinbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Rooms_RoomId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetup_Items_ItemsId",
                table: "ItemSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetup_Setups_SetupsId",
                table: "ItemSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_Setups_Rooms_RoomId",
                table: "Setups");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setups",
                table: "Setups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Setups",
                newName: "Setup");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Setups_RoomId",
                table: "Setup",
                newName: "IX_Setup_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_RoomId",
                table: "Item",
                newName: "IX_Item_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setup",
                table: "Setup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Rooms_RoomId",
                table: "Item",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetup_Item_ItemsId",
                table: "ItemSetup",
                column: "ItemsId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetup_Setup_SetupsId",
                table: "ItemSetup",
                column: "SetupsId",
                principalTable: "Setup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Setup_Rooms_RoomId",
                table: "Setup",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Rooms_RoomId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetup_Item_ItemsId",
                table: "ItemSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetup_Setup_SetupsId",
                table: "ItemSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_Setup_Rooms_RoomId",
                table: "Setup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setup",
                table: "Setup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Setup",
                newName: "Setups");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Setup_RoomId",
                table: "Setups",
                newName: "IX_Setups_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_RoomId",
                table: "Items",
                newName: "IX_Items_RoomId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setups",
                table: "Setups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Rooms_RoomId",
                table: "Items",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetup_Items_ItemsId",
                table: "ItemSetup",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetup_Setups_SetupsId",
                table: "ItemSetup",
                column: "SetupsId",
                principalTable: "Setups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Setups_Rooms_RoomId",
                table: "Setups",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    public partial class addnullforeinKeycategoryIdforitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Items_ItemId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Items_ItemId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Defect_Items_ItemId",
                table: "Defect");

            migrationBuilder.DropForeignKey(
                name: "FK_DefectPhoto_Defect_DefectId",
                table: "DefectPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefectPhoto",
                table: "DefectPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Defect",
                table: "Defect");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "DefectPhoto",
                newName: "DefectPhotos");

            migrationBuilder.RenameTable(
                name: "Defect",
                newName: "Defects");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "CurrentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                newName: "IX_Items_CurrentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DefectPhoto_DefectId",
                table: "DefectPhotos",
                newName: "IX_DefectPhotos_DefectId");

            migrationBuilder.RenameIndex(
                name: "IX_Defect_ItemId",
                table: "Defects",
                newName: "IX_Defects_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ItemId",
                table: "Comments",
                newName: "IX_Comments_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_ItemId",
                table: "Attachments",
                newName: "IX_Attachments_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefectPhotos",
                table: "DefectPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Defects",
                table: "Defects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrigUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPhotos_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPhotos_ItemId",
                table: "ItemPhotos",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Items_ItemId",
                table: "Attachments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefectPhotos_Defects_DefectId",
                table: "DefectPhotos",
                column: "DefectId",
                principalTable: "Defects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Defects_Items_ItemId",
                table: "Defects",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CurrentCategoryId",
                table: "Items",
                column: "CurrentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Items_ItemId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DefectPhotos_Defects_DefectId",
                table: "DefectPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Defects_Items_ItemId",
                table: "Defects");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CurrentCategoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Defects",
                table: "Defects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefectPhotos",
                table: "DefectPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Defects",
                newName: "Defect");

            migrationBuilder.RenameTable(
                name: "DefectPhotos",
                newName: "DefectPhoto");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameColumn(
                name: "CurrentCategoryId",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CurrentCategoryId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Defects_ItemId",
                table: "Defect",
                newName: "IX_Defect_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DefectPhotos_DefectId",
                table: "DefectPhoto",
                newName: "IX_DefectPhoto_DefectId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ItemId",
                table: "Comment",
                newName: "IX_Comment_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ItemId",
                table: "Attachment",
                newName: "IX_Attachment_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Defect",
                table: "Defect",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefectPhoto",
                table: "DefectPhoto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Items_ItemId",
                table: "Attachment",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Items_ItemId",
                table: "Comment",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Defect_Items_ItemId",
                table: "Defect",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefectPhoto_Defect_DefectId",
                table: "DefectPhoto",
                column: "DefectId",
                principalTable: "Defect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

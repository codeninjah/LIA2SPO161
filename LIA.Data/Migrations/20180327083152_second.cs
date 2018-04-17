using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LIA.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Modules_ListItemId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Downloads_Modules_ListItemId",
                table: "Downloads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Downloads",
                table: "Downloads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "UserCourses",
                newName: "UserProducts");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "ListItems");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "ItemTypes");

            migrationBuilder.RenameTable(
                name: "Downloads",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Downloads_ListItemId",
                table: "Items",
                newName: "IX_Items_ListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_ListItemId",
                table: "Products",
                newName: "IX_Products_ListItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems",
                column: "ListItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes",
                column: "ItemTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ListItems_ListItemId",
                table: "Items",
                column: "ListItemId",
                principalTable: "ListItems",
                principalColumn: "ListItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ListItems_ListItemId",
                table: "Products",
                column: "ListItemId",
                principalTable: "ListItems",
                principalColumn: "ListItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ListItems_ListItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ListItems_ListItemId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "UserProducts",
                newName: "UserCourses");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "ListItems",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "ItemTypes",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Downloads");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ListItemId",
                table: "Courses",
                newName: "IX_Courses_ListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ListItemId",
                table: "Downloads",
                newName: "IX_Downloads_ListItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ListItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "ItemTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Downloads",
                table: "Downloads",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Modules_ListItemId",
                table: "Courses",
                column: "ListItemId",
                principalTable: "Modules",
                principalColumn: "ListItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Downloads_Modules_ListItemId",
                table: "Downloads",
                column: "ListItemId",
                principalTable: "Modules",
                principalColumn: "ListItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

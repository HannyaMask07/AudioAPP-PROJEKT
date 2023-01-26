using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class NewMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdentityUserId",
                table: "AspNetUsers",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdentityUserId",
                table: "AspNetUsers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUsers");
        }
    }
}

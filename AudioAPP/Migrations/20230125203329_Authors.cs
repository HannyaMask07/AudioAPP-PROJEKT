using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class Authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Audios_AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Author_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_AudioId",
                table: "Author",
                column: "AudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AudioId",
                table: "AspNetUsers",
                column: "AudioId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Audios_AudioId",
                table: "AspNetUsers",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class InitialP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Audios_AudiosAudioId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AudiosAudioId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AudiosAudioId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AudioId",
                table: "Comments",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Audios_AudioId",
                table: "Comments",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "AudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Audios_AudioId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AudioId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AudiosAudioId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AudiosAudioId",
                table: "Comments",
                column: "AudiosAudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Audios_AudiosAudioId",
                table: "Comments",
                column: "AudiosAudioId",
                principalTable: "Audios",
                principalColumn: "AudioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

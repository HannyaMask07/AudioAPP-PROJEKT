using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AudioId",
                table: "AspNetUsers",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Audios_AudioId",
                table: "AspNetUsers",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Audios_AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}

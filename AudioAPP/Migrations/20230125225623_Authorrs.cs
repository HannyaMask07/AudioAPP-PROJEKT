using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class Authorrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Audios_AudioId",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Author_AudioId",
                table: "Authors",
                newName: "IX_Authors_AudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Audios_AudioId",
                table: "Authors",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Audios_AudioId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_AudioId",
                table: "Author",
                newName: "IX_Author_AudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Audios_AudioId",
                table: "Author",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id");
        }
    }
}

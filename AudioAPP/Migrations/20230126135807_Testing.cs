using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Audios_AudioId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_AudioId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Audios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audios_AuthorId",
                table: "Audios",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Authors_AuthorId",
                table: "Audios",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Authors_AuthorId",
                table: "Audios");

            migrationBuilder.DropIndex(
                name: "IX_Audios_AuthorId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Audios");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AudioId",
                table: "Authors",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Audios_AudioId",
                table: "Authors",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id");
        }
    }
}

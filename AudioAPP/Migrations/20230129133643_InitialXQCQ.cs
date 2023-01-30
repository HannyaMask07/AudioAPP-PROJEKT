using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class InitialXQCQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bbcb29-0f91-471b-822c-d15863c88719");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c40d0069-f9f1-4625-99fe-74945d210eb9");

            migrationBuilder.CreateTable(
                name: "AudioLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioLikes_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e4b1e57-e491-40fc-97cf-f4e97767b942", "109b5f4b-24b2-4db0-bbc6-c8cedaa2af75", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b4a0f5f-b2d6-4149-bf11-766dfc5ce42a", "ff2cc5c4-00d5-4c02-b954-0f99ce71d7d9", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_AudioLikes_AudioId",
                table: "AudioLikes",
                column: "AudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioLikes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e4b1e57-e491-40fc-97cf-f4e97767b942");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b4a0f5f-b2d6-4149-bf11-766dfc5ce42a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73bbcb29-0f91-471b-822c-d15863c88719", "55b285ce-e505-48a7-9e8d-140293cccb89", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c40d0069-f9f1-4625-99fe-74945d210eb9", "69843119-0aa4-4760-8fb2-4aa241743810", "Admin", "ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class InitialXQC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33981aa3-0142-4b96-a553-71d3b183a322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a864a8a-a5af-4b75-b658-cb1c4800cfca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73bbcb29-0f91-471b-822c-d15863c88719", "55b285ce-e505-48a7-9e8d-140293cccb89", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c40d0069-f9f1-4625-99fe-74945d210eb9", "69843119-0aa4-4760-8fb2-4aa241743810", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bbcb29-0f91-471b-822c-d15863c88719");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c40d0069-f9f1-4625-99fe-74945d210eb9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33981aa3-0142-4b96-a553-71d3b183a322", "38433b7c-3958-482b-8873-c087cf539dfc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a864a8a-a5af-4b75-b658-cb1c4800cfca", "60f21390-a7c8-4836-945f-06778a677fa7", "User", "USER" });
        }
    }
}

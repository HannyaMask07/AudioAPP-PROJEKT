using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioAPP.Migrations
{
    public partial class InitialOPGGGG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5597d974-43a2-43c3-b82a-b4f7b58bf886");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af16734f-9ef9-4402-9e45-6e8039f0f5f3");

            migrationBuilder.AddColumn<int>(
                name: "Priorities",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33981aa3-0142-4b96-a553-71d3b183a322", "38433b7c-3958-482b-8873-c087cf539dfc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a864a8a-a5af-4b75-b658-cb1c4800cfca", "60f21390-a7c8-4836-945f-06778a677fa7", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33981aa3-0142-4b96-a553-71d3b183a322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a864a8a-a5af-4b75-b658-cb1c4800cfca");

            migrationBuilder.DropColumn(
                name: "Priorities",
                table: "Profiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5597d974-43a2-43c3-b82a-b4f7b58bf886", "2ed35202-f341-46b2-91b3-bf91fbf726fd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af16734f-9ef9-4402-9e45-6e8039f0f5f3", "007c89cd-1c12-48dc-a2f9-53cd4bb46c44", "Admin", "ADMIN" });
        }
    }
}

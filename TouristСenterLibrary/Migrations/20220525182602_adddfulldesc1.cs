using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class adddfulldesc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Route",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1,
                column: "FullDescription",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2,
                column: "FullDescription",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3,
                column: "FullDescription",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                column: "FullDescription",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                column: "FullDescription",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6,
                column: "FullDescription",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Route");
        }
    }
}

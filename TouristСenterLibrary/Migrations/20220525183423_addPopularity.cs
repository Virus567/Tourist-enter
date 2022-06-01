using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class addPopularity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Route",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1,
                column: "Popularity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2,
                column: "Popularity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3,
                column: "Popularity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                column: "Popularity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                column: "Popularity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6,
                column: "Popularity",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Route");
        }
    }
}

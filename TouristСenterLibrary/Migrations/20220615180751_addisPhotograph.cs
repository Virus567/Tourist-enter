using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class addisPhotograph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPhotograph",
                table: "Order",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Поющие пески");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                column: "NumberDays",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPhotograph",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Поющие пески Вятки");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                column: "NumberDays",
                value: 3);
        }
    }
}

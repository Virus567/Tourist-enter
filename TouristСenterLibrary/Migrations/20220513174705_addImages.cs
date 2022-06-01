using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class addImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Route",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1,
                column: "Images",
                value: new[] { "1", "2", "3" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2,
                column: "Images",
                value: new[] { "1", "2", "3" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3,
                column: "Images",
                value: new[] { "1", "2", "3" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                column: "Images",
                value: new[] { "1", "2", "3" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                column: "Images",
                value: new[] { "1", "2", "3" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6,
                column: "Images",
                value: new[] { "1", "2", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Route");
        }
    }
}

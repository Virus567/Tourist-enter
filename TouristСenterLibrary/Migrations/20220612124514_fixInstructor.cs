using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class fixInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Instructor",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Instructor",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Discription", "Image" },
                values: new object[] { "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Instructor");
        }
    }
}

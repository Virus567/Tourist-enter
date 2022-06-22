using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class fixParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InGroup",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Participant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InGroup",
                table: "Participant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Participant",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

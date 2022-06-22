using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class addInstructorInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_InstructorID",
                table: "Order",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Instructor_InstructorID",
                table: "Order",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Instructor_InstructorID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_InstructorID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Order");
        }
    }
}

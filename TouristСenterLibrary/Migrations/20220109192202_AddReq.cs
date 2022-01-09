using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class AddReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Hike_HikeID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "HikeID",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Hike_HikeID",
                table: "Order",
                column: "HikeID",
                principalTable: "Hike",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Hike_HikeID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "HikeID",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Hike_HikeID",
                table: "Order",
                column: "HikeID",
                principalTable: "Hike",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

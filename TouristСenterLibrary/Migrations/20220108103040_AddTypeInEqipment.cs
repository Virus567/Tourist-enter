using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class AddTypeInEqipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentHike_Equipment_EquipmentsID",
                table: "EquipmentHike");

            migrationBuilder.RenameColumn(
                name: "EquipmentsID",
                table: "EquipmentHike",
                newName: "EquipmentsListID");

            migrationBuilder.RenameColumn(
                name: "CountableEquipmentsID",
                table: "CountableEquipmentHike",
                newName: "CountableEquipmentsListID");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Equipment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentHike_Equipment_EquipmentsListID",
                table: "EquipmentHike",
                column: "EquipmentsListID",
                principalTable: "Equipment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentHike_Equipment_EquipmentsListID",
                table: "EquipmentHike");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "EquipmentsListID",
                table: "EquipmentHike",
                newName: "EquipmentsID");

            migrationBuilder.RenameColumn(
                name: "CountableEquipmentsListID",
                table: "CountableEquipmentHike",
                newName: "CountableEquipmentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentHike_Equipment_EquipmentsID",
                table: "EquipmentHike",
                column: "EquipmentsID",
                principalTable: "Equipment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

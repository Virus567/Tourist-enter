using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TouristСenterLibrary.Migrations
{
    public partial class AddCountableHikeEquipment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountableEquipmentHike");

            migrationBuilder.CreateTable(
                name: "CountableHikeEquipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountableEquipmentID = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    HikeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountableHikeEquipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountableHikeEquipment_CountableEquipment_CountableEquipmen~",
                        column: x => x.CountableEquipmentID,
                        principalTable: "CountableEquipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountableHikeEquipment_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquipment_CountableEquipmentID",
                table: "CountableHikeEquipment",
                column: "CountableEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquipment_HikeID",
                table: "CountableHikeEquipment",
                column: "HikeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountableHikeEquipment");

            migrationBuilder.CreateTable(
                name: "CountableEquipmentHike",
                columns: table => new
                {
                    CountableEquipmentsListID = table.Column<int>(type: "integer", nullable: false),
                    HikesListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountableEquipmentHike", x => new { x.CountableEquipmentsListID, x.HikesListID });
                    table.ForeignKey(
                        name: "FK_CountableEquipmentHike_CountableEquipment_CountableEquipmen~",
                        column: x => x.CountableEquipmentsListID,
                        principalTable: "CountableEquipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountableEquipmentHike_Hike_HikesListID",
                        column: x => x.HikesListID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountableEquipmentHike_HikesListID",
                table: "CountableEquipmentHike",
                column: "HikesListID");
        }
    }
}

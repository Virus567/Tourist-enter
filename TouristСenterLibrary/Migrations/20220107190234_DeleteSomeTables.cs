using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TouristСenterLibrary.Migrations
{
    public partial class DeleteSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Client_ClientID",
                table: "Participant");

            migrationBuilder.DropTable(
                name: "CountableHikeEquip");

            migrationBuilder.DropTable(
                name: "HikeEquipment");

            migrationBuilder.DropTable(
                name: "HikeFood");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Participant",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CountableEquipmentHike",
                columns: table => new
                {
                    CountableEquipmentsID = table.Column<int>(type: "integer", nullable: false),
                    HikesListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountableEquipmentHike", x => new { x.CountableEquipmentsID, x.HikesListID });
                    table.ForeignKey(
                        name: "FK_CountableEquipmentHike_CountableEquipment_CountableEquipmen~",
                        column: x => x.CountableEquipmentsID,
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

            migrationBuilder.CreateTable(
                name: "EquipmentHike",
                columns: table => new
                {
                    EquipmentsID = table.Column<int>(type: "integer", nullable: false),
                    HikesListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentHike", x => new { x.EquipmentsID, x.HikesListID });
                    table.ForeignKey(
                        name: "FK_EquipmentHike_Equipment_EquipmentsID",
                        column: x => x.EquipmentsID,
                        principalTable: "Equipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentHike_Hike_HikesListID",
                        column: x => x.HikesListID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountableEquipmentHike_HikesListID",
                table: "CountableEquipmentHike",
                column: "HikesListID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentHike_HikesListID",
                table: "EquipmentHike",
                column: "HikesListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Client_ClientID",
                table: "Participant",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Client_ClientID",
                table: "Participant");

            migrationBuilder.DropTable(
                name: "CountableEquipmentHike");

            migrationBuilder.DropTable(
                name: "EquipmentHike");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Participant",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CountableHikeEquip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentID = table.Column<int>(type: "integer", nullable: true),
                    HikeID = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountableHikeEquip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountableHikeEquip_CountableEquipment_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "CountableEquipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountableHikeEquip_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HikeEquipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentID = table.Column<int>(type: "integer", nullable: true),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikeEquipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HikeEquipment_Equipment_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HikeEquipment_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HikeFood",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodID = table.Column<int>(type: "integer", nullable: true),
                    HikeID = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ShelfLife = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikeFood", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HikeFood_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HikeFood_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquip_EquipmentID",
                table: "CountableHikeEquip",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquip_HikeID",
                table: "CountableHikeEquip",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_HikeEquipment_EquipmentID",
                table: "HikeEquipment",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_HikeEquipment_HikeID",
                table: "HikeEquipment",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_HikeFood_FoodID",
                table: "HikeFood",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_HikeFood_HikeID",
                table: "HikeFood",
                column: "HikeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Client_ClientID",
                table: "Participant",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

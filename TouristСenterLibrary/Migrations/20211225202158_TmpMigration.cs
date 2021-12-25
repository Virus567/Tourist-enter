using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class TmpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteHike_CheckpointRoute_HaltID",
                table: "RouteHike");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "RouteHike");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "RouteHike");

            migrationBuilder.RenameColumn(
                name: "HaltID",
                table: "RouteHike",
                newName: "HikeID");

            migrationBuilder.RenameIndex(
                name: "IX_RouteHike_HaltID",
                table: "RouteHike",
                newName: "IX_RouteHike_HikeID");

            migrationBuilder.AddColumn<int>(
                name: "HermeticBagAmount",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndividualTentAmount",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildrenAmount",
                table: "Client",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteHike_Hike_HikeID",
                table: "RouteHike",
                column: "HikeID",
                principalTable: "Hike",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteHike_Hike_HikeID",
                table: "RouteHike");

            migrationBuilder.DropColumn(
                name: "HermeticBagAmount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IndividualTentAmount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ChildrenAmount",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "HikeID",
                table: "RouteHike",
                newName: "HaltID");

            migrationBuilder.RenameIndex(
                name: "IX_RouteHike_HikeID",
                table: "RouteHike",
                newName: "IX_RouteHike_HaltID");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "RouteHike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "RouteHike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_RouteHike_CheckpointRoute_HaltID",
                table: "RouteHike",
                column: "HaltID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

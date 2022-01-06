using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class ChangeRouteCheckpointRouteHike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckpointRoute_Route_RouteID",
                table: "CheckpointRoute");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteHike_CheckpointRoute_FinishID",
                table: "RouteHike");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteHike_CheckpointRoute_StartID",
                table: "RouteHike");

            migrationBuilder.DropIndex(
                name: "IX_RouteHike_FinishID",
                table: "RouteHike");

            migrationBuilder.DropIndex(
                name: "IX_RouteHike_StartID",
                table: "RouteHike");

            migrationBuilder.DropIndex(
                name: "IX_CheckpointRoute_RouteID",
                table: "CheckpointRoute");

            migrationBuilder.DropColumn(
                name: "FinishID",
                table: "RouteHike");

            migrationBuilder.DropColumn(
                name: "StartID",
                table: "RouteHike");

            migrationBuilder.DropColumn(
                name: "RouteID",
                table: "CheckpointRoute");

            migrationBuilder.RenameColumn(
                name: "TargetStop",
                table: "CheckpointRoute",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CheckpointRoute",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "CheckpointFinishID",
                table: "Route",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckpointStartID",
                table: "Route",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Route",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CheckpointFinishID",
                table: "Route",
                column: "CheckpointFinishID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CheckpointStartID",
                table: "Route",
                column: "CheckpointStartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                table: "Route",
                column: "CheckpointFinishID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointStartID",
                table: "Route",
                column: "CheckpointStartID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointStartID",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_CheckpointFinishID",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_CheckpointStartID",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "CheckpointFinishID",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "CheckpointStartID",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CheckpointRoute",
                newName: "TargetStop");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CheckpointRoute",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "FinishID",
                table: "RouteHike",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartID",
                table: "RouteHike",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteID",
                table: "CheckpointRoute",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_FinishID",
                table: "RouteHike",
                column: "FinishID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_StartID",
                table: "RouteHike",
                column: "StartID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckpointRoute_RouteID",
                table: "CheckpointRoute",
                column: "RouteID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckpointRoute_Route_RouteID",
                table: "CheckpointRoute",
                column: "RouteID",
                principalTable: "Route",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteHike_CheckpointRoute_FinishID",
                table: "RouteHike",
                column: "FinishID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteHike_CheckpointRoute_StartID",
                table: "RouteHike",
                column: "StartID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

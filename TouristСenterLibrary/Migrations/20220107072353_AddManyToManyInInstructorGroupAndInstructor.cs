using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class AddManyToManyInInstructorGroupAndInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorGroup_Instructor_InstructorID",
                table: "InstructorGroup");

            migrationBuilder.DropIndex(
                name: "IX_InstructorGroup_InstructorID",
                table: "InstructorGroup");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "InstructorGroup");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Route",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InstructorInstructorGroup",
                columns: table => new
                {
                    InstructorGroupsID = table.Column<int>(type: "integer", nullable: false),
                    InstructorsListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorInstructorGroup", x => new { x.InstructorGroupsID, x.InstructorsListID });
                    table.ForeignKey(
                        name: "FK_InstructorInstructorGroup_Instructor_InstructorsListID",
                        column: x => x.InstructorsListID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorInstructorGroup_InstructorGroup_InstructorGroupsID",
                        column: x => x.InstructorGroupsID,
                        principalTable: "InstructorGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorInstructorGroup_InstructorsListID",
                table: "InstructorInstructorGroup",
                column: "InstructorsListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorInstructorGroup");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Route",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "InstructorGroup",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorGroup_InstructorID",
                table: "InstructorGroup",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorGroup_Instructor_InstructorID",
                table: "InstructorGroup",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

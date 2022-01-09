using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class MyLastMigrationPeredSnosom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyTelefonNumber",
                table: "TransportCompany",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_TransportCompany_CompanyTelefonNumber",
                table: "TransportCompany",
                newName: "IX_TransportCompany_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ClientTelefonNumber",
                table: "Participant",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "InstructorTelefonNumber",
                table: "Instructor",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_InstructorTelefonNumber",
                table: "Instructor",
                newName: "IX_Instructor_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "EmployeeTelefonNumber",
                table: "Employee",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmployeeTelefonNumber",
                table: "Employee",
                newName: "IX_Employee_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ClientTelefonNumber",
                table: "Client",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "TransportCompany",
                newName: "CompanyTelefonNumber");

            migrationBuilder.RenameIndex(
                name: "IX_TransportCompany_PhoneNumber",
                table: "TransportCompany",
                newName: "IX_TransportCompany_CompanyTelefonNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Participant",
                newName: "ClientTelefonNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Instructor",
                newName: "InstructorTelefonNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_PhoneNumber",
                table: "Instructor",
                newName: "IX_Instructor_InstructorTelefonNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employee",
                newName: "EmployeeTelefonNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PhoneNumber",
                table: "Employee",
                newName: "IX_Employee_EmployeeTelefonNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Client",
                newName: "ClientTelefonNumber");
        }
    }
}

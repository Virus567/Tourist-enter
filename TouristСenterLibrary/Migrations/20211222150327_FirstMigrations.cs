using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TouristСenterLibrary.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOfCompany = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    ClientTelefonNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PeopleAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountableEquipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountableEquipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
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
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    PassportData = table.Column<string>(type: "text", nullable: false),
                    InstructorTelefonNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransportCompany",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CompanyTelefonNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompany", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    ClientTelefonNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participant_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    PassportData = table.Column<string>(type: "text", nullable: false),
                    EmployeeTelefonNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckpointRoute",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TargetStop = table.Column<string>(type: "text", nullable: false),
                    RouteID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckpointRoute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckpointRoute_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteID = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hike_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarNumber = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SeatCount = table.Column<int>(type: "integer", nullable: false),
                    TransportCompanyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transport_TransportCompany_TransportCompanyID",
                        column: x => x.TransportCompanyID,
                        principalTable: "TransportCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountableHikeEquip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentID = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
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
                name: "HikeEquipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentID = table.Column<int>(type: "integer", nullable: true),
                    EquipmentFeatures = table.Column<string>(type: "text", nullable: true),
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
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    ShelfLife = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "InstructorGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstructorID = table.Column<int>(type: "integer", nullable: true),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InstructorGroup_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorGroup_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationTypeID = table.Column<int>(type: "integer", nullable: true),
                    RouteID = table.Column<int>(type: "integer", nullable: true),
                    EmployeeID = table.Column<int>(type: "integer", nullable: true),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    WayToTravel = table.Column<string>(type: "text", nullable: false),
                    FoodlFeatures = table.Column<string>(type: "text", nullable: true),
                    EquipmentFeatures = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_ApplicationType_ApplicationTypeID",
                        column: x => x.ApplicationTypeID,
                        principalTable: "ApplicationType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteHike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteID = table.Column<int>(type: "integer", nullable: true),
                    StartID = table.Column<int>(type: "integer", nullable: true),
                    FinishID = table.Column<int>(type: "integer", nullable: true),
                    HaltID = table.Column<int>(type: "integer", nullable: true),
                    StartBusID = table.Column<int>(type: "integer", nullable: true),
                    FinishBusID = table.Column<int>(type: "integer", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteHike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RouteHike_CheckpointRoute_FinishID",
                        column: x => x.FinishID,
                        principalTable: "CheckpointRoute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteHike_CheckpointRoute_HaltID",
                        column: x => x.HaltID,
                        principalTable: "CheckpointRoute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteHike_CheckpointRoute_StartID",
                        column: x => x.StartID,
                        principalTable: "CheckpointRoute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteHike_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteHike_Transport_FinishBusID",
                        column: x => x.FinishBusID,
                        principalTable: "Transport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteHike_Transport_StartBusID",
                        column: x => x.StartBusID,
                        principalTable: "Transport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckpointRoute_RouteID",
                table: "CheckpointRoute",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquip_EquipmentID",
                table: "CountableHikeEquip",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquip_HikeID",
                table: "CountableHikeEquip",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTelefonNumber",
                table: "Employee",
                column: "EmployeeTelefonNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PassportData",
                table: "Employee",
                column: "PassportData",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleID",
                table: "Employee",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Hike_RouteID",
                table: "Hike",
                column: "RouteID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_InstructorTelefonNumber",
                table: "Instructor",
                column: "InstructorTelefonNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_PassportData",
                table: "Instructor",
                column: "PassportData",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorGroup_HikeID",
                table: "InstructorGroup",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorGroup_InstructorID",
                table: "InstructorGroup",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationTypeID",
                table: "Order",
                column: "ApplicationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_HikeID",
                table: "Order",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RouteID",
                table: "Order",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ClientID",
                table: "Participant",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_FinishBusID",
                table: "RouteHike",
                column: "FinishBusID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_FinishID",
                table: "RouteHike",
                column: "FinishID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_HaltID",
                table: "RouteHike",
                column: "HaltID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_RouteID",
                table: "RouteHike",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_StartBusID",
                table: "RouteHike",
                column: "StartBusID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_StartID",
                table: "RouteHike",
                column: "StartID");

            migrationBuilder.CreateIndex(
                name: "IX_Transport_CarNumber",
                table: "Transport",
                column: "CarNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transport_TransportCompanyID",
                table: "Transport",
                column: "TransportCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompany_CompanyTelefonNumber",
                table: "TransportCompany",
                column: "CompanyTelefonNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountableHikeEquip");

            migrationBuilder.DropTable(
                name: "HikeEquipment");

            migrationBuilder.DropTable(
                name: "HikeFood");

            migrationBuilder.DropTable(
                name: "InstructorGroup");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "RouteHike");

            migrationBuilder.DropTable(
                name: "CountableEquipment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Hike");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CheckpointRoute");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "TransportCompany");
        }
    }
}

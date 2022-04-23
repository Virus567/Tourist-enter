using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TouristСenterLibrary.Migrations
{
    public partial class addLoginAndPass : Migration
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
                name: "CheckpointRoute",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckpointRoute", x => x.ID);
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
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassportData = table.Column<string>(type: "text", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
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
                name: "TransportCompany",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompany", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NameOfCompany = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberDays = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CheckpointStartID = table.Column<int>(type: "integer", nullable: false),
                    CheckpointFinishID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                        column: x => x.CheckpointFinishID,
                        principalTable: "CheckpointRoute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_CheckpointRoute_CheckpointStartID",
                        column: x => x.CheckpointStartID,
                        principalTable: "CheckpointRoute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassportData = table.Column<string>(type: "text", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarNumber = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SeatCount = table.Column<int>(type: "integer", nullable: false),
                    TransportCompanyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transport_TransportCompany_TransportCompanyID",
                        column: x => x.TransportCompanyID,
                        principalTable: "TransportCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeopleAmount = table.Column<int>(type: "integer", nullable: false),
                    ChildrenAmount = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TouristGroup_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
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
                name: "Participant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TouristGroupID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    InGroup = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participant_TouristGroup_TouristGroupID",
                        column: x => x.TouristGroupID,
                        principalTable: "TouristGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "EquipmentHike",
                columns: table => new
                {
                    EquipmentsListID = table.Column<int>(type: "integer", nullable: false),
                    HikesListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentHike", x => new { x.EquipmentsListID, x.HikesListID });
                    table.ForeignKey(
                        name: "FK_EquipmentHike_Equipment_EquipmentsListID",
                        column: x => x.EquipmentsListID,
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

            migrationBuilder.CreateTable(
                name: "InstructorGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    TouristGroupID = table.Column<int>(type: "integer", nullable: true),
                    WayToTravel = table.Column<string>(type: "text", nullable: false),
                    FoodlFeatures = table.Column<string>(type: "text", nullable: true),
                    EquipmentFeatures = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    HikeID = table.Column<int>(type: "integer", nullable: true),
                    HermeticBagAmount = table.Column<int>(type: "integer", nullable: false),
                    IndividualTentAmount = table.Column<int>(type: "integer", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Order_TouristGroup_TouristGroupID",
                        column: x => x.TouristGroupID,
                        principalTable: "TouristGroup",
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
                    StartBusID = table.Column<int>(type: "integer", nullable: true),
                    FinishBusID = table.Column<int>(type: "integer", nullable: true),
                    HikeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteHike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RouteHike_Hike_HikeID",
                        column: x => x.HikeID,
                        principalTable: "Hike",
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

            migrationBuilder.InsertData(
                table: "ApplicationType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Семейная" },
                    { 2, "Корпоративная" }
                });

            migrationBuilder.InsertData(
                table: "CheckpointRoute",
                columns: new[] { "ID", "Title", "Type" },
                values: new object[,]
                {
                    { 12, "г. Киров, Заречный парк", "Финиш" },
                    { 11, "г. Нововятск, Набережная", "Старт" },
                    { 10, "Слободской р-он, д. Бошарово", "Финиш" },
                    { 9, "Оричевский р-он, д. Решетники", "Старт" },
                    { 7, "Советский р-он, п. Петропавловское", "Старт" },
                    { 8, "Лебяжский р-он, д. Приверх", "Финиш" },
                    { 5, "Юрьянский р-он, устье р. Великая", "Старт" },
                    { 4, "Белохолуницкий р-он, п.Стеклофилины", "Финиш" },
                    { 3, "Нагорский р-он, Летский рейд", "Старт" },
                    { 2, "Советский р-он, д. Долбилово", "Финиш" },
                    { 1, "Советский р-он, д. Фокино", "Старт" },
                    { 6, "Орловский р-он, г. Орлов", "Финиш" }
                });

            migrationBuilder.InsertData(
                table: "CountableEquipment",
                columns: new[] { "ID", "Name", "Number" },
                values: new object[,]
                {
                    { 7, "Весло", 120 },
                    { 10, "Костровые стойки", 10 },
                    { 9, "Котелок 8л", 9 },
                    { 8, "Котелок 10л", 10 },
                    { 6, "Палатка Lair2", 22 },
                    { 11, "Гермомешок", 142 },
                    { 4, "Палатка Lair4", 40 },
                    { 3, "Канистра", 50 },
                    { 2, "Спальник", 139 },
                    { 1, "Коврик", 150 },
                    { 5, "Палатка Lair3", 15 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "ID", "Name", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 29, "Байдарка2 T", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 30, "Байдарка2 U", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 31, "Байдарка3 I", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak3" },
                    { 32, "Байдарка3 J", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak3" },
                    { 33, "Байдарка3 Q", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak3" },
                    { 34, "Байдарка3 K", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak3" },
                    { 35, "Байдарка3 P", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak3" },
                    { 36, "Беседка A", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavilion" },
                    { 37, "Беседка B", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavilion" },
                    { 38, "Беседка C", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavilion" },
                    { 39, "Беседка D", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavilion" },
                    { 42, "Складной стол №2", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 41, "Складной стол №1", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 43, "Складной стол №3", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 44, "Складной стол №4", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 45, "Складной стол №5", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 46, "Складной стол №6", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "table" },
                    { 47, "Топор H", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ax" },
                    { 48, "Топор N", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ax" },
                    { 49, "Топор Q", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ax" },
                    { 50, "Топор T", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ax" },
                    { 56, "Топор Y", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ax" },
                    { 28, "Байдарка2 S", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 40, "Беседка F", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavilion" },
                    { 27, "Байдарка2 R", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 20, "Байдарка2 J", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 25, "Байдарка2 P", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 1, "Рафт A", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 2, "Рафт D", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 3, "Рафт K", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 4, "Рафт L", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 5, "Рафт M", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 26, "Байдарка2 Q", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 8, "Рафт S", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 9, "Рафт X", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 10, "Рафт Q", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 11, "Байдарка2 A", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 12, "Байдарка2 B", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 6, "Рафт R", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "raft" },
                    { 14, "Байдарка2 D", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 15, "Байдарка2 E", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 16, "Байдарка2 F", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 17, "Байдарка2 G", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 18, "Байдарка2 H", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 19, "Байдарка2 I", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 21, "Байдарка2 K", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 22, "Байдарка2 L", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 23, "Байдарка2 M", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 24, "Байдарка2 O", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" },
                    { 13, "Байдарка2 C", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayak2" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "ID", "EmploymentDate", "Login", "Middlename", "Name", "PassportData", "Password", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 10, new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr10", "Николаевна", "Анна", "3317 266312", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79122433993", "Калугина" },
                    { 9, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr9", "Константинович", "Евгений", "3316 452301", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79539716504", "Жилин" },
                    { 8, new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr8", "Артёмович", "Марк", "3315 821423", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79129717101", "Судаков" },
                    { 7, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr7", "Вадимировна", "Ангелина", "3314 552314", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79533402030", "Лазарева" },
                    { 6, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr6", "Тимурович", "Фёдор", "3316 225485", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79225854707", "Журавлев" },
                    { 1, new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr1", "Александровна", "Алиса", "3314 568475", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79222106611", "Петрова" },
                    { 4, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr4", "Романович", "Тимофей", "3316 564523", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79128029498", "Горбунов" },
                    { 3, new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr3", "Михайлович", "Артём", "3316 895123", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79122023227", "Степанов" },
                    { 2, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr2", "Арсентьевна", "Екатерина", "3315 264512", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79536523958", "Зуева" },
                    { 5, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "instr5", "Михайлович", "Даниил", "3315 258965", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "+79123687951", "Новиков" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "PositionName" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "TransportCompany",
                columns: new[] { "ID", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Довезем", "+79127262438" },
                    { 2, "Автокар", "+79227126472" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "EmploymentDate", "Middlename", "Name", "PassportData", "PhoneNumber", "RoleID", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Матвеевич", "Леонид", "3316 345677", "+79532521240", 1, "Кондрашов" },
                    { 2, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мироновна", "Анастасия", "3314 861234", "+79129750710", 1, "Шишкина" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "ID", "CheckpointFinishID", "CheckpointStartID", "Description", "Name", "NumberDays" },
                values: new object[,]
                {
                    { 1, 2, 1, "Красавица река НЕМДА является жемчужиной Вятского края", "Любимая Немда", 3 },
                    { 2, 4, 3, "Затерянный мир На Вятке", "Затерянный мир", 3 },
                    { 3, 6, 5, "Великолепный маршрут Родные просторы по берегам реки Вятки", "Родные просторы", 3 },
                    { 4, 8, 7, "Поющие пески Вятки ", "Поющие пески Вятки", 3 },
                    { 5, 10, 9, "Очень красивые и живописные места, на очень быстрой и стремительной реке Быстрице", "Быстрая вода", 3 },
                    { 6, 12, 11, "С воды раскрываются все красоты города Кирова", "Город с воды", 1 }
                });

            migrationBuilder.InsertData(
                table: "Transport",
                columns: new[] { "ID", "CarNumber", "SeatCount", "TransportCompanyID" },
                values: new object[,]
                {
                    { 3, "Д563ТА", 50, 1 },
                    { 5, "К532СУ", 17, 1 },
                    { 6, "Т532МА", 13, 1 },
                    { 1, "У356РА", 40, 2 },
                    { 2, "А215УР", 25, 2 },
                    { 4, "К921БД", 27, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquipment_CountableEquipmentID",
                table: "CountableHikeEquipment",
                column: "CountableEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CountableHikeEquipment_HikeID",
                table: "CountableHikeEquipment",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PassportData",
                table: "Employee",
                column: "PassportData",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PhoneNumber",
                table: "Employee",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleID",
                table: "Employee",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentHike_HikesListID",
                table: "EquipmentHike",
                column: "HikesListID");

            migrationBuilder.CreateIndex(
                name: "IX_Hike_RouteID",
                table: "Hike",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_PassportData",
                table: "Instructor",
                column: "PassportData",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_PhoneNumber",
                table: "Instructor",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorGroup_HikeID",
                table: "InstructorGroup",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorInstructorGroup_InstructorsListID",
                table: "InstructorInstructorGroup",
                column: "InstructorsListID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationTypeID",
                table: "Order",
                column: "ApplicationTypeID");

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
                name: "IX_Order_TouristGroupID",
                table: "Order",
                column: "TouristGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TouristGroupID",
                table: "Participant",
                column: "TouristGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_UserID",
                table: "Participant",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CheckpointFinishID",
                table: "Route",
                column: "CheckpointFinishID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CheckpointStartID",
                table: "Route",
                column: "CheckpointStartID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_FinishBusID",
                table: "RouteHike",
                column: "FinishBusID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_HikeID",
                table: "RouteHike",
                column: "HikeID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_RouteID",
                table: "RouteHike",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHike_StartBusID",
                table: "RouteHike",
                column: "StartBusID");

            migrationBuilder.CreateIndex(
                name: "IX_TouristGroup_UserID",
                table: "TouristGroup",
                column: "UserID");

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
                name: "IX_TransportCompany_PhoneNumber",
                table: "TransportCompany",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountableHikeEquipment");

            migrationBuilder.DropTable(
                name: "EquipmentHike");

            migrationBuilder.DropTable(
                name: "InstructorInstructorGroup");

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
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "InstructorGroup");

            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TouristGroup");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Hike");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TransportCompany");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "CheckpointRoute");
        }
    }
}

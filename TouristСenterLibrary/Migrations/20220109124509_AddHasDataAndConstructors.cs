using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class AddHasDataAndConstructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointStartID",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Transport_TransportCompany_TransportCompanyID",
                table: "Transport");

            migrationBuilder.AlterColumn<int>(
                name: "TransportCompanyID",
                table: "Transport",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CheckpointStartID",
                table: "Route",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CheckpointFinishID",
                table: "Route",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                columns: new[] { "ID", "EmploymentDate", "InstructorTelefonNumber", "Middlename", "Name", "PassportData", "Surname" },
                values: new object[,]
                {
                    { 10, new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79122433993", "Николаевна", "Анна", "3317 266312", "Калугина" },
                    { 9, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79539716504", "Константинович", "Евгений", "3316 452301", "Жилин" },
                    { 8, new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79129717101", "Артёмович", "Марк", "3315 821423", "Судаков" },
                    { 7, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79533402030", "Вадимировна", "Ангелина", "3314 552314", "Лазарева" },
                    { 6, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79225854707", "Тимурович", "Фёдор", "3316 225485", "Журавлев" },
                    { 1, new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79222106611", "Александровна", "Алиса", "3314 568475", "Петрова" },
                    { 4, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79128029498", "Романович", "Тимофей", "3316 564523", "Горбунов" },
                    { 3, new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79122023227", "Михайлович", "Артём", "3316 895123", "Степанов" },
                    { 2, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79536523958", "Арсентьевна", "Екатерина", "3315 264512", "Зуева" },
                    { 5, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "+79123687951", "Михайлович", "Даниил", "3315 258965", "Новиков" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "PositionName" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "TransportCompany",
                columns: new[] { "ID", "CompanyTelefonNumber", "Name" },
                values: new object[,]
                {
                    { 1, "+79127262438", "Довезем" },
                    { 2, "+79227126472", "Автокар" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "EmployeeTelefonNumber", "EmploymentDate", "Middlename", "Name", "PassportData", "RoleID", "Surname" },
                values: new object[,]
                {
                    { 1, "+79532521240", new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Матвеевич", "Леонид", "3316 345677", 1, "Кондрашов" },
                    { 2, "+79129750710", new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мироновна", "Анастасия", "3314 861234", 1, "Шишкина" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                table: "Route",
                column: "CheckpointFinishID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointStartID",
                table: "Route",
                column: "CheckpointStartID",
                principalTable: "CheckpointRoute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transport_TransportCompany_TransportCompanyID",
                table: "Transport",
                column: "TransportCompanyID",
                principalTable: "TransportCompany",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointFinishID",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_CheckpointRoute_CheckpointStartID",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Transport_TransportCompany_TransportCompanyID",
                table: "Transport");

            migrationBuilder.DeleteData(
                table: "ApplicationType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CountableEquipment",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transport",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CheckpointRoute",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportCompany",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportCompany",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "TransportCompanyID",
                table: "Transport",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CheckpointStartID",
                table: "Route",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CheckpointFinishID",
                table: "Route",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "Employee",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transport_TransportCompany_TransportCompanyID",
                table: "Transport",
                column: "TransportCompanyID",
                principalTable: "TransportCompany",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

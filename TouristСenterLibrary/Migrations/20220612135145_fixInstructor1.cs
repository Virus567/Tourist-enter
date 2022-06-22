using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class fixInstructor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1,
                column: "Discription",
                value: "Профессиональный повар. Могу приготовить на костре все что угодно от вкусной и наваристой ухи до блинов на завтрак.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2,
                column: "Discription",
                value: "Веселый Аниматор. Закончила цироковое училище, вожу в походы уже 7 лет.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3,
                column: "Discription",
                value: "Старший инструктор. Мастер в своем деле. С детства увлекаюсь походами, охотой и рыбалкой.Со мной не пропадете.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4,
                column: "Discription",
                value: "Мастер спорта по гребле. Байдарка для меня — смысл жизни. С самого детства в ней, со мной не пропадете.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 5,
                column: "Discription",
                value: "Старший инструктор. Вожу в походы уже 15 лет. Знаю все маршруты вдоль и поперек.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 6,
                column: "Discription",
                value: "Душа компании. Со мной не соскучитесь. Со мной можно поговорить в любое время и на любые темы.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 7,
                column: "Discription",
                value: "А вы пробовали когда-нибудь яичницу, приготовленную на костре или аппетитные оладьи на свежем воздухе? Со мной обязательно попробуете!");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 8,
                column: "Discription",
                value: "Мастер на все руки. Сколотить деревянный помост? Сделать скамейки, чтобы посидеть у костра? Это все ко мне.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 9,
                column: "Discription",
                value: "Профессиональный экскурсовод. Проведу увлекательную экскурсию на любом маршруте, расскажу про все интересные места.");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 10,
                column: "Discription",
                value: "Хорошо играю на гитаре. Вечером у костра со мной не заскучаете. ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 5,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 6,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 7,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 8,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 9,
                column: "Discription",
                value: "");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 10,
                column: "Discription",
                value: "");
        }
    }
}

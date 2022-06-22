using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristСenterLibrary.Migrations
{
    public partial class fixRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "Красавица река НЕМДА является жемчужиной Вятского края. Природа этих мест уникальна: выходы известняковых скал, рельефные берега, бурлящие перекаты, самый высокий водопад Кировской области, чистая родниковая вода, отсутствие комаров, живописные пейзажи", "Nemda" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "Затерянный мир На Вятке. Маршрут, где можно насладиться по настоящему дикой природой, редкими расстениями и ощутить настоящее единение с природой. ", "Vyatka" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "Великолепный маршрут Родные просторы по берегам реки Вятки подарит огромное количество позитивных эмоций и незабываемых впечатлений.", "Vyatka" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "У заброшенной деревни Атары в Кировской области, где Вятка делает крутой поворот, находится трехкилометровая отмель с белым песком из горного хрусталя и молочного кварца. ", "Vyatka" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "Очень красивые и живописные места, на очень быстрой и стремительной реке Быстрице откроются перед вами если вы посетите этот маршрут", "Bystrica" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "С воды раскрываются все красоты города Кирова. Появляется возможность насладиться ими прямо с водной глаяди реки Вятки.", "Vyatka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Немда" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Вятка" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Вятка" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Вятка" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Быстрица" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "FullDescription", "River" },
                values: new object[] { "1", "Вятка" });
        }
    }
}

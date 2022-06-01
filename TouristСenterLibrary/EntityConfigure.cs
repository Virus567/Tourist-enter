using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TouristСenterLibrary.Entity;

namespace TouristСenterLibrary
{
    public static class EntityConfigure
    {
        public static void RoleConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role("admin") { ID = 1 });
        }
        public static void ApplicationTypeConfigure(EntityTypeBuilder<ApplicationType> builder)
        {
            builder.HasData(new ApplicationType("Семейная") { ID = 1 });
            builder.HasData(new ApplicationType("Корпоративная") { ID = 2 });
        }
        public static void CheckpointRouteConfigure(EntityTypeBuilder<CheckpointRoute> builder)
        {
            List<CheckpointRoute> checkpointRoutes = new List<CheckpointRoute>();
            checkpointRoutes.Add(new CheckpointRoute("Советский р-он, д. Фокино", "Старт") { ID = 1 });
            checkpointRoutes.Add(new CheckpointRoute("Советский р-он, д. Долбилово", "Финиш") { ID = 2 });
            checkpointRoutes.Add(new CheckpointRoute("Нагорский р-он, Летский рейд", "Старт") { ID = 3 });
            checkpointRoutes.Add(new CheckpointRoute("Белохолуницкий р-он, п.Стеклофилины", "Финиш") { ID = 4 });
            checkpointRoutes.Add(new CheckpointRoute("Юрьянский р-он, устье р. Великая", "Старт") { ID = 5 });
            checkpointRoutes.Add(new CheckpointRoute("Орловский р-он, г. Орлов", "Финиш") { ID = 6 });
            checkpointRoutes.Add(new CheckpointRoute("Советский р-он, п. Петропавловское", "Старт") { ID = 7 });
            checkpointRoutes.Add(new CheckpointRoute("Лебяжский р-он, д. Приверх", "Финиш") { ID = 8 });
            checkpointRoutes.Add(new CheckpointRoute("Оричевский р-он, д. Решетники", "Старт") { ID = 9 });
            checkpointRoutes.Add(new CheckpointRoute("Слободской р-он, д. Бошарово", "Финиш") { ID = 10 });
            checkpointRoutes.Add(new CheckpointRoute("г. Нововятск, Набережная", "Старт") { ID = 11 });
            checkpointRoutes.Add(new CheckpointRoute("г. Киров, Заречный парк", "Финиш") { ID = 12 });
            builder.HasData(checkpointRoutes);
        }
        public static void RouteConfigure(EntityTypeBuilder<Route> builder)
        {
            List<Route> routes = new List<Route>();
            routes.Add(new Route("Любимая Немда", 3, "Красавица река НЕМДА является жемчужиной Вятского края") { ID = 1, FullDescription="1", Popularity = 1, CheckpointStartID = 1, CheckpointFinishID = 2, River = "Немда", Images =  new string[] { "1", "2", "3" } });
            routes.Add(new Route("Затерянный мир", 3, "Затерянный мир На Вятке") { ID = 2, FullDescription = "1", Popularity = 1, CheckpointStartID = 3, CheckpointFinishID = 4, River = "Вятка", Images = new string[] { "1", "2", "3" } });
            routes.Add(new Route("Родные просторы", 3, "Великолепный маршрут Родные просторы по берегам реки Вятки") { ID = 3, FullDescription = "1", Popularity = 1, CheckpointStartID = 5, CheckpointFinishID = 6, River = "Вятка", Images = new string[] { "1", "2", "3" } });
            routes.Add(new Route("Поющие пески Вятки", 3, "Поющие пески Вятки ") { ID = 4, FullDescription = "1", Popularity = 1, CheckpointStartID = 7, CheckpointFinishID = 8, River = "Вятка", Images = new string[] { "1", "2", "3" } });
            routes.Add(new Route("Быстрая вода", 3, "Очень красивые и живописные места, на очень быстрой и стремительной реке Быстрице") { ID = 5, FullDescription = "1", Popularity = 1, CheckpointStartID = 9, CheckpointFinishID = 10, River = "Быстрица", Images = new string[] { "1", "2", "3" } });
            routes.Add(new Route("Город с воды", 1, "С воды раскрываются все красоты города Кирова") { ID = 6, FullDescription = "1", Popularity = 1, CheckpointStartID = 11, CheckpointFinishID = 12, River = "Вятка", Images = new string[] { "1", "2", "3" } });
            builder.HasData(routes);
        }
        public static void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
        }

        public static void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.HasIndex(s => s.PassportData).IsUnique();
            builder.HasData(new Employee("Кондрашов", "Леонид", "Матвеевич", "3316 345677", "+79532521240", DateTime.Parse("12/2/2020 00:00")) { ID = 1, RoleID =1});
            builder.HasData(new Employee("Шишкина", "Анастасия", "Мироновна", "3314 861234", "+79129750710", DateTime.Parse("12/2/2020 00:00")) { ID = 2, RoleID = 1 });
        }
        public static void TransportCompanyConfigure(EntityTypeBuilder<TransportCompany> builder)
        {
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.HasData(new TransportCompany("Довезем", "+79127262438") { ID = 1 });
            builder.HasData(new TransportCompany("Автокар", "+79227126472") { ID = 2 });
        }

        public static void TransportConfigure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasIndex(s => s.CarNumber).IsUnique();
            List<Transport> transports = new List<Transport>();
            transports.Add(new Transport("У356РА", 40) { ID = 1, TransportCompanyID = 2 });
            transports.Add(new Transport("А215УР", 25) { ID = 2, TransportCompanyID = 2 });
            transports.Add(new Transport("Д563ТА", 50) { ID = 3, TransportCompanyID = 1 });
            transports.Add(new Transport("К921БД", 27) { ID = 4, TransportCompanyID = 2 });
            transports.Add(new Transport("К532СУ", 17) { ID = 5, TransportCompanyID = 1 });
            transports.Add(new Transport("Т532МА", 13) { ID = 6, TransportCompanyID = 1 });
            builder.HasData(transports);
        }
        public static void InstructorConfigure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.HasIndex(s => s.PassportData).IsUnique();
            List<Instructor> instructors = new List<Instructor>();
            instructors.Add(new Instructor("Петрова", "Алиса", "Александровна", "3314 568475", "+79222106611", DateTime.Parse("7/8/2019 00:00")) { ID = 1, Login = "instr1", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Зуева", "Екатерина", "Арсентьевна", "3315 264512", "+79536523958", DateTime.Parse("6/6/2020 00:00")) { ID = 2, Login = "instr2", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Степанов", "Артём", "Михайлович", "3316 895123", "+79122023227", DateTime.Parse("8/7/2021 00:00")) { ID = 3, Login = "instr3", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Горбунов", "Тимофей", "Романович", "3316 564523", "+79128029498", DateTime.Parse("8/8/2020 00:00")) { ID = 4, Login = "instr4", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Новиков", "Даниил", "Михайлович", "3315 258965", "+79123687951", DateTime.Parse("5/5/2021 00:00")) { ID = 5, Login = "instr5", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Журавлев", "Фёдор", "Тимурович", "3316 225485", "+79225854707", DateTime.Parse("6/5/2020 00:00")) { ID = 6, Login = "instr6", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Лазарева", "Ангелина", "Вадимировна", "3314 552314", "+79533402030", DateTime.Parse("7/5/2021 00:00")) { ID = 7, Login = "instr7", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Судаков", "Марк", "Артёмович", "3315 821423", "+79129717101", DateTime.Parse("5/7/2020 00:00")) { ID = 8, Login = "instr8", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Жилин", "Евгений", "Константинович", "3316 452301", "+79539716504", DateTime.Parse("5/6/2021 00:00")) { ID = 9, Login = "instr9", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            instructors.Add(new Instructor("Калугина", "Анна", "Николаевна", "3317 266312", "+79122433993", DateTime.Parse("5/5/2019 00:00")) { ID = 10, Login = "instr10", Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" });
            builder.HasData(instructors);
        }
        public static void EquipmentConfigure(EntityTypeBuilder<Equipment> builder)
        {
            List<Equipment> equipments = new List<Equipment>();
            equipments.Add(new Equipment("Рафт A", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 1});
            equipments.Add(new Equipment("Рафт D", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 2 });
            equipments.Add(new Equipment("Рафт K", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 3 });
            equipments.Add(new Equipment("Рафт L", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 4 });
            equipments.Add(new Equipment("Рафт M", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 5 });
            equipments.Add(new Equipment("Рафт R", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 6 });
            equipments.Add(new Equipment("Рафт S", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 8 });
            equipments.Add(new Equipment("Рафт X", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 9 });
            equipments.Add(new Equipment("Рафт Q", DateTime.Parse("7/8/2019 00:00"), "raft") { ID = 10 });
            equipments.Add(new Equipment("Байдарка2 A", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 11 });
            equipments.Add(new Equipment("Байдарка2 B", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 12 });
            equipments.Add(new Equipment("Байдарка2 C", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 13 });
            equipments.Add(new Equipment("Байдарка2 D", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 14 });
            equipments.Add(new Equipment("Байдарка2 E", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 15 });
            equipments.Add(new Equipment("Байдарка2 F", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 16 });
            equipments.Add(new Equipment("Байдарка2 G", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 17 });
            equipments.Add(new Equipment("Байдарка2 H", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 18 });
            equipments.Add(new Equipment("Байдарка2 I", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 19 });
            equipments.Add(new Equipment("Байдарка2 J", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 20 });
            equipments.Add(new Equipment("Байдарка2 K", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 21 });
            equipments.Add(new Equipment("Байдарка2 L", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 22 });
            equipments.Add(new Equipment("Байдарка2 M", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 23 });
            equipments.Add(new Equipment("Байдарка2 O", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 24 });
            equipments.Add(new Equipment("Байдарка2 P", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 25 });
            equipments.Add(new Equipment("Байдарка2 Q", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 26 });
            equipments.Add(new Equipment("Байдарка2 R", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 27 });
            equipments.Add(new Equipment("Байдарка2 S", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 28 });
            equipments.Add(new Equipment("Байдарка2 T", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 29 });
            equipments.Add(new Equipment("Байдарка2 U", DateTime.Parse("7/8/2019 00:00"), "kayak2") { ID = 30 });
            equipments.Add(new Equipment("Байдарка3 I", DateTime.Parse("7/8/2019 00:00"), "kayak3") { ID = 31 });
            equipments.Add(new Equipment("Байдарка3 J", DateTime.Parse("7/8/2019 00:00"), "kayak3") { ID = 32 });
            equipments.Add(new Equipment("Байдарка3 Q", DateTime.Parse("7/8/2019 00:00"), "kayak3") { ID = 33 });
            equipments.Add(new Equipment("Байдарка3 K", DateTime.Parse("7/8/2019 00:00"), "kayak3") { ID = 34 });
            equipments.Add(new Equipment("Байдарка3 P", DateTime.Parse("7/8/2019 00:00"), "kayak3") { ID = 35 });
            equipments.Add(new Equipment("Беседка A", DateTime.Parse("7/8/2019 00:00"), "pavilion") { ID = 36 });
            equipments.Add(new Equipment("Беседка B", DateTime.Parse("7/8/2019 00:00"), "pavilion") { ID = 37 });
            equipments.Add(new Equipment("Беседка C", DateTime.Parse("7/8/2019 00:00"), "pavilion") { ID = 38 });
            equipments.Add(new Equipment("Беседка D", DateTime.Parse("7/8/2019 00:00"), "pavilion") { ID = 39 });
            equipments.Add(new Equipment("Беседка F", DateTime.Parse("7/8/2019 00:00"), "pavilion") { ID = 40 });
            equipments.Add(new Equipment("Складной стол №1", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 41 });
            equipments.Add(new Equipment("Складной стол №2", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 42 });
            equipments.Add(new Equipment("Складной стол №3", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 43 });
            equipments.Add(new Equipment("Складной стол №4", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 44 });
            equipments.Add(new Equipment("Складной стол №5", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 45 });
            equipments.Add(new Equipment("Складной стол №6", DateTime.Parse("7/8/2019 00:00"), "table") { ID = 46 });
            equipments.Add(new Equipment("Топор H", DateTime.Parse("7/8/2019 00:00"), "ax") { ID = 47 });
            equipments.Add(new Equipment("Топор N", DateTime.Parse("7/8/2019 00:00"), "ax") { ID = 48 });
            equipments.Add(new Equipment("Топор Q", DateTime.Parse("7/8/2019 00:00"), "ax") { ID = 49 });
            equipments.Add(new Equipment("Топор T", DateTime.Parse("7/8/2019 00:00"), "ax") { ID = 50 });
            equipments.Add(new Equipment("Топор Y", DateTime.Parse("7/8/2019 00:00"), "ax") { ID = 56 });
            builder.HasData(equipments);
        }
        public static void CountableEquipmentConfigure(EntityTypeBuilder<CountableEquipment> builder)
        {
            List<CountableEquipment> countableEquipments = new List<CountableEquipment>();
            countableEquipments.Add(new CountableEquipment("Коврик", 150) { ID = 1 });
            countableEquipments.Add(new CountableEquipment("Спальник", 139) { ID = 2 });
            countableEquipments.Add(new CountableEquipment("Канистра", 50) { ID = 3 });
            countableEquipments.Add(new CountableEquipment("Палатка Lair4", 40) { ID = 4 });
            countableEquipments.Add(new CountableEquipment("Палатка Lair3", 15) { ID = 5 });
            countableEquipments.Add(new CountableEquipment("Палатка Lair2", 22) { ID = 6 });
            countableEquipments.Add(new CountableEquipment("Весло", 120) { ID = 7 });
            countableEquipments.Add(new CountableEquipment("Котелок 10л", 10) { ID = 8 });
            countableEquipments.Add(new CountableEquipment("Котелок 8л", 9) { ID = 9 });
            countableEquipments.Add(new CountableEquipment("Костровые стойки", 10) { ID = 10 });
            countableEquipments.Add(new CountableEquipment("Гермомешок", 142) { ID = 11});
            builder.HasData(countableEquipments);
        }
    }
}

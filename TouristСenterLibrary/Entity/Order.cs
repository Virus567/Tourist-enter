using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TouristСenterLibrary;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace TouristСenterLibrary.Entity
{
    public class Order 
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual ApplicationType ApplicationType { get; set; }
        [Required] public virtual Route Route { get; set; }
        [Required] public virtual Employee Employee { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required] public string WayToTravel { get; set; }
        public string FoodlFeatures { get; set; }
        public string EquipmentFeatures { get; set; }
        [Required] public DateTime StartTime { get; set; }
        [Required] public DateTime FinishTime { get; set; }
        [Required] public string Status { get; set; }
        public virtual Hike Hike { get; set; }
        [Required] public int HermeticBagAmount { get; set; }
        [Required] public int IndividualTentAmount { get; set; }

        public enum EnumStatus
        {
            [Description("Активна")] active = 1,
            [Description("В сборке")] onRoute = 2,
            [Description("Завершена")] сompleted = 3,
            [Description("Отменена")] canceled = 4
        }


        public class OrderView
        {
            public int ID { get; set; }
            public string DateTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string Client { get; set; }
            public int ClientID { get; set;}
            public int PeopleAmount { get; set; }
            public int ChildrenAmount { get; set; }
            public string ApplicationTypeName { get; set; }
            public string Status { get; set; }
            public bool IsListParticipants { get; set; }
        }

        public static List<OrderView> GetView()
        {
            List<OrderView> list = (from o in db.Order
                    select new OrderView()
                    {
                        ID = o.ID,
                        DateTime = o.StartTime.ToString("d"),
                        RouteName = o.Route.Name,
                        WayToTravel = o.WayToTravel,
                        Client = o.Client.GetCompanyNameForOrder(),
                        ClientID = o.Client.ID,
                        PeopleAmount = o.Client.PeopleAmount,
                        ApplicationTypeName = o.ApplicationType.Name,
                        ChildrenAmount = o.Client.ChildrenAmount,
                        Status = o.Status,
                        IsListParticipants = false
                    }).ToList();
            foreach(var l in list)
            {
                l.IsListParticipants = Participant.IsParticipantsForOrder(Client.GetClientByID(l.ClientID));
            }
            return list;
        }
        public class OrderViewAll
        {
            public int ID { get; set; }
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string Client { get; set; }
            public int ClientID { get; set; }
            public int PeopleAmount { get; set; }
            public int ChildrenAmount { get; set; }
            public string ApplicationType { get; set; }
            public string Status { get; set; }
            public int HermeticBagAmount { get; set; }
            public int IndividualTentAmount { get; set; }
            public string FoodlFeatures { get; set; }
            public string EquipmentFeatures { get; set; }
            public bool IsListParticipants { get; set; }

        }

        public static void Add(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
        }

        public static void Update(Order order)
        {
            db.Order.Update(order);
            db.SaveChanges();
        }
        public static OrderViewAll GetViewAllByID(int orderID)
        {
            OrderViewAll order = (from o in db.Order
                                       where o.ID == orderID                    
                                       select new OrderViewAll()
                                       {
                                            ID = orderID,
                                            StartTime = o.StartTime.ToString("d"),
                                            FinishTime = o.FinishTime.ToString("d"),
                                            RouteName = o.Route.Name,
                                            WayToTravel = o.WayToTravel,
                                            Client = o.Client.GetCompanyNameForOrder(),
                                            ClientID = o.Client.ID,
                                            PeopleAmount = o.Client.PeopleAmount,
                                            ApplicationType = o.ApplicationType.Name,
                                            ChildrenAmount =o.Client.ChildrenAmount,
                                            FoodlFeatures = o.FoodlFeatures,
                                            EquipmentFeatures = o.EquipmentFeatures,
                                            Status = o.Status,
                                            HermeticBagAmount = o.HermeticBagAmount,
                                            IndividualTentAmount =o.IndividualTentAmount
                                       }).FirstOrDefault();
            order.IsListParticipants = Participant.IsParticipantsForOrder(Client.GetClientByID(order.ClientID));
            return order;
        }
        public static Order GetOrderByID(int orderID)
        {
            return db.Order.Where(o => o.ID == orderID).FirstOrDefault();
        }

        public static List<string> GetPossibleStatuses(string str)
        {
            EnumStatus startStatus = GetEnumByDescription<EnumStatus>(str);
            List<string> list = new List<string>();
            foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
            {
                if (status >= startStatus)
                {
                    list.Add(GetDescriptionByEnum(status));
                }
            }
            return list;
        }
        public static string GetDescriptionByEnum(Enum enumElement)
        {
            Type type = enumElement.GetType();
            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return enumElement.ToString();
        }
        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Enum is not found!", nameof(description));
        }

    }
}

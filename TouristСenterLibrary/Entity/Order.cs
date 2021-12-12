using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TouristСenterLibrary;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Order 
    {
        public int ID { get; set; }
        [Required] public  ApplicationType ApplicationType { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public Employee Employee { get; set; }
        [Required] public Client Client { get; set; }
        //[Required] public int ClientId { get; set; }
        [Required] public string WayToTravel { get; set; }
        public string FoodlFeatures { get; set; }
        public string EquipmentFeatures { get; set; }
        [Required] public DateTime StartTime { get; set; }
        [Required] public DateTime FinishTime { get; set; }
        [Required] public string Status { get; set; }
        public Hike Hike { get; set; }

        public class OrderView 
        {
            public int ID { get; set; }
            public string DateTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string Client { get; set; }
            public int PeopleAmount { get; set; }
            public string ApplicationTypeName { get; set; }
            public string Status { get; set; }
        }
        public static List<OrderView> GetView()
        {
            using(var db = new ApplicationContext())
            {
                return (from o in db.Order
                        select new OrderView()
                        {
                            ID = o.ID,
                            DateTime = o.StartTime.ToString("d"),
                            RouteName = o.Route.Name,
                            WayToTravel = o.WayToTravel,
                            Client = o.Client.GetCompanyNameForOrder(),
                            PeopleAmount = o.Client.PeopleAmount,
                            ApplicationTypeName = o.ApplicationType.Name,
                            Status = o.Status
                        }).ToList();
            }
        }
        public class OrderViewAll
        {
            public int ID { get; set; }
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string Client { get; set; }
            public int PeopleAmount { get; set; }
            public string ApplicationType { get; set; }
            public string Status { get; set; }
        }

        public static List<OrderViewAll> GetViewAll(int orderID)
        {
            using (var db = new ApplicationContext())
            {
                return (from o in db.Order
                        where o.ID == orderID                    
                        select new OrderViewAll()
                        {
                            ID = orderID,
                            StartTime = o.StartTime.ToString("d"),
                            FinishTime = o.FinishTime.ToString("d"),
                            RouteName = o.Route.Name,
                            WayToTravel = o.WayToTravel,
                            Client = o.Client.GetCompanyNameForOrder(),
                            PeopleAmount = o.Client.PeopleAmount,
                            ApplicationType = o.ApplicationType.Name,
                            Status = o.Status
                        }).ToList();
            }
        }
        public static Order GetOrderByID(int orderID)
        {
            using (var db = new ApplicationContext())
            {
               List<Order> list = db.Order.Where(o => o.ID == orderID).ToList();
               return list[0];
            }
            
        }
    }
}

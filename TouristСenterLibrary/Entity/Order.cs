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
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual ApplicationType ApplicationType { get; set; }
        [Required] public virtual Route Route { get; set; }
        [Required] public virtual Employee Employee { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required] public string WayToTravel { get; set; }
        public string? FoodlFeatures { get; set; }
        public string? EquipmentFeatures { get; set; }
        [Required] public DateTime StartTime { get; set; }
        [Required] public DateTime FinishTime { get; set; }
        [Required] public string Status { get; set; }
        public virtual Hike? Hike { get; set; }
        [Required] public int HermeticBagAmount { get; set; }
        [Required] public int IndividualTentAmount { get; set; }

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
            public bool IsListParticipants { get; set; }
        }

        public static List<OrderView> GetView()
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
                        Status = o.Status,
                        IsListParticipants = Participant.IsParticipantForOrder(o.Client.ID)
                    }).ToList();
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
            // public int HermeticBagAmount { get; set; }
            // public int IndividualTentAmount { get; set; }
            //public string FoodlFeatures { get; set; }
            //public string EquipmentFeatures { get; set; }

        }

        public static int GetHermeticBagAmount(int hikeId)
        {
            int result = 0;
            List<Order> orders = (from o in db.Order
                                  join h in db.Hike on o.Hike.ID equals h.ID
                                  where h.ID == hikeId
                                  select o).ToList();
            //foreach(Order or in orders)
            //{
            //    result += or.HermeticBagAmount;
            //}
            return result;
        }
        public static int GetIndividualTentAmount(int hikeId)
        {
            int result = 0;
            List<Order> orders = (from o in db.Order
                                  join h in db.Hike on o.Hike.ID equals h.ID
                                  where h.ID == hikeId
                                  select o).ToList();
            //foreach (Order or in orders)
            //{
            //    result += or.IndividualTentAmount;
            //}
            return result;
        }


        public static List<OrderViewAll> GetViewAll(int orderID)
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
                        //HermeticBagAmount = o.HermeticBagAmount,
                        //IndividualTentAmount =o.IndividualTentAmount
                    }).ToList();
        }
        public static Order GetOrderByID(int orderID)
        {
            return db.Order.Where(o => o.ID == orderID).FirstOrDefault();                
        }


    }
}

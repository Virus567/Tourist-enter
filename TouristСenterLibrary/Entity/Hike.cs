using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Hike
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public string Status { get; set; }

        public static List<Hike> Get()
        {
            return db.Hike.ToList();

        }
        public class HikeView
        {
            public int ID { get; set; }
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string CompanyName { get; set; }
            public int PeopleAmount { get; set; }
            public string Status { get; set; }
        }
        public static List<HikeView> GetView()
        {   // Исправить этот метод !!!
            List<Order> orders = Order.GetOrders();
            return db.Hike.Join(db.Order, h => h.ID, o => o.ID, (h, o) => new HikeView()
            {
                ID = h.ID,               
                StartTime = o.StartTime.ToString("d"),
                FinishTime = o.FinishTime.ToString("d"),
                RouteName = h.Route.Name,
                WayToTravel = o.WayToTravel,
                CompanyName = o.Client.GetCompanyNameForHike(),
                //PeopleAmount = o.Client.GetPeopleAmountOfHike(orders.Where(or => or.Hike.ID ==h.ID).ToList()),
                PeopleAmount = o.Client.PeopleAmount,
                Status = h.Status
            }).ToList();
        }

        public class HikeViewAll
        {
            public int ID { get; set; }
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string CompanyName { get; set; }
            public int PeopleAmount { get; set; }
            public string Status { get; set; }
        }

        public static List<HikeViewAll> GetViewByID(int hikeID)
        {           
            return (from h in db.Hike
                    join o in db.Order on h.ID equals o.Hike.ID
                    join c in db.Client on o.ID equals c.ID
                    where h.ID == hikeID
                    select new HikeViewAll()
                    {
                        ID = hikeID,
                        StartTime = o.StartTime.ToString("d"),
                        FinishTime = o.FinishTime.ToString("d"),
                        RouteName = h.Route.Name,
                        WayToTravel = o.WayToTravel,
                        CompanyName = o.Client.GetCompanyNameForHike(),
                        PeopleAmount = c.PeopleAmount,
                        Status = h.Status
                    }).ToList();
        }
        public static int GetPeopleAmountOfHike(int hikeID)
        {
            int tmp = 0;
            List<HikeViewAll> list = GetViewByID(hikeID);
                foreach (HikeViewAll l in list)
                {
                    tmp += l.PeopleAmount;
                }
            return tmp;
        }
        
    }
}

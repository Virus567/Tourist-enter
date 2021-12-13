using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Hike
    {
        public int ID { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public string Status { get; set; }

        public static List<Hike> Get()
        {
            using(var db = new ApplicationContext())
            {
                return db.Hike.ToList();
            }
        }
        public class HikeView
        {
            public int ID { get; set; }
            public string DateTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string CompanyName { get; set; }
            public int PeopleAmount { get; set; }
            public string Status { get; set; }
        }
        public static List<HikeView> GetView()
        {
            using (var db = new ApplicationContext())
            {
                //return (from h in db.Hike
                //        join o in db.Order on h.ID equals o.Hike.ID
                //        select new HikeView()
                //        {
                //            ID = h.ID,
                //            DateTime = o.StartTime.ToString("d"),
                //            RouteName = h.Route.Name,
                //            WayToTravel = o.WayToTravel,
                //            CompanyName = o.Client.GetCompanyNameForHike(),
                //            PeopleAmount = o.Client.GetPeopleAmountOfHike(h.ID),
                //            Status = h.Status
                //        }).ToList();
                return db.Hike.Join(db.Order, h => h.ID, o => o.ID, (h, o) => new HikeView()
                {
                    ID = h.ID,
                    DateTime = o.StartTime.ToString("d"),
                    RouteName = h.Route.Name,
                    WayToTravel = o.WayToTravel,
                    CompanyName = o.Client.GetCompanyNameForHike(),
                    PeopleAmount = o.Client.GetPeopleAmountOfHike(h.ID),
                    Status = h.Status
                }).ToList();
            }
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

        public static List<HikeViewAll> GetViewAll(int hikeID)
        {
            using (var db = new ApplicationContext())
            {
                return (from h in db.Hike
                        where h.ID == hikeID
                        join o in db.Order on h.ID equals o.Hike.ID
                        join c in db.Client on o.ID equals c.ID
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
                //return db.Hike.Join(db.Order, h => h.ID, o => o.ID, (h, o) => new HikeViewAll()
                //{
                //    ID = hikeID,
                //    StartTime = o.StartTime.ToString("d"),
                //    FinishTime = o.FinishTime.ToString("d"),
                //    RouteName = h.Route.Name,
                //    WayToTravel = o.WayToTravel,
                //    CompanyName = o.Client.GetCompanyNameForHike(),
                //    PeopleAmount = o.Client.PeopleAmount,
                //    Status = h.Status
                //}).ToList(); 
            }
        }
        public static int GetPeopleAmountOfHike(int hikeID)
        {
            int tmp = 0;
            List<HikeViewAll> list = GetViewAll(hikeID);
                foreach (HikeViewAll l in list)
                {
                    tmp += l.PeopleAmount;
                }
            return tmp;
        }
        
    }
}

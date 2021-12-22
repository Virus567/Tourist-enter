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
        {
            List<HikeView> hikeList = db.Hike.Join(db.Order, h => h.ID, o => o.ID, (h, o) => new HikeView()
            {
                ID = h.ID,               
                StartTime = o.StartTime.ToString("d"),
                FinishTime = o.FinishTime.ToString("d"),
                RouteName = h.Route.Name,
                WayToTravel = o.WayToTravel,
                CompanyName = o.Client.GetCompanyNameForHike(),             
                PeopleAmount = o.Client.PeopleAmount,
                Status = h.Status
            }).ToList();

            foreach (HikeView hike in hikeList)
            {
                hike.PeopleAmount = Hike.GetPeopleAmountOfHike(hike.ID);
            }
            return hikeList;
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
            // public int HermeticBagAmount { get; set; }
            // public int IndividualTentAmount { get; set; }
        }

        public static List<HikeViewAll> GetViewByID(int hikeID)
        {
            List<HikeViewAll>list = (from h in db.Hike
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
                        //  HermeticBagAmount = o.HermeticBagAmount,
                        //  IndividualTentAmount =o.IndividualTentAmount
                    }).ToList();
            //foreach(HikeViewAll hv in list)
            //{
            //    hv.HermeticBagAmount = Order.GetHermeticBagAmount(hv.ID);
            //    hv.IndividualTentAmount = Order.GetIndividualTentAmount(hv.ID);
            //}
            return list;
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

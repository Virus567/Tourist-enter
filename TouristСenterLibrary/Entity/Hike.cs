﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class Hike
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual Route Route { get; set; }
        [Required] public string Status { get; set; }

        public static void Add(Hike hike)
        {
            db.Hike.Add(hike);
            db.SaveChanges();
        }

        public static Hike GetHikeByID(int hikeId)
        {
            return db.Hike.Where(h => h.ID == hikeId).First();
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
            List<HikeView> hikeList =db.Hike.Join(db.Order, h => h.ID, o => o.ID, (h, o) => new HikeView()
            {
                ID = h.ID,
                RouteName = h.Route.Name,
                WayToTravel = o.WayToTravel,
                CompanyName = o.Client.GetCompanyNameForHike(),
                PeopleAmount = o.Client.PeopleAmount,
                Status = h.Status
            }).ToList();

            foreach (HikeView hike in hikeList)
            {
                hike.PeopleAmount = GetPeopleAmountOfHike(hike.ID);
                var viewHike = GetViewAllByID(hike.ID);
                hike.CompanyName = viewHike.FirstOrDefault().CompanyName;
                hike.StartTime = viewHike.FirstOrDefault().StartTime;
                hike.FinishTime = viewHike.FirstOrDefault().FinishTime;
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
            public int ChildrenAmount { get; set; }
            public string Status { get; set; }
            public int HermeticBagAmount { get; set; }
            public int IndividualTentAmount { get; set; }
        }

        public static List<HikeViewAll> GetViewAllByID(int hikeID)
        {
            List<HikeViewAll>list = (from h in db.Hike
                    join o in db.Order on h.ID equals o.Hike.ID
                    join c in db.Client on o.Client.ID equals c.ID
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
                        Status = h.Status,                   
                    }).ToList();
            foreach (HikeViewAll hv in list)
            {
                hv.HermeticBagAmount = Order.GetHermeticBagAmount(hv.ID);
                hv.IndividualTentAmount = Order.GetIndividualTentAmount(hv.ID);
                hv.ChildrenAmount = Client.GetChildrenAmountOnHike(hv.ID);
            }
            return list;
        }
        public static int GetPeopleAmountOfHike(int hikeID)
        {
            int tmp = 0;
            List<HikeViewAll> list = GetViewAllByID(hikeID);
                foreach (HikeViewAll l in list)
                {
                    tmp += l.PeopleAmount;
                }
            return tmp;
        }
        
    }
}

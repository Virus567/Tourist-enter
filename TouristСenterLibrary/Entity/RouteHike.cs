using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class RouteHike
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual Route Route { get; set; }
        [Required] public virtual Transport StartBus { get; set; }
        [Required] public virtual Transport FinishBus { get; set;}
        [Required] public virtual Hike Hike { get; set; }


        public static void Add(RouteHike routeHike)
        {
            db.RouteHike.Add(routeHike);
            db.SaveChanges();
        }
        public static void Update(RouteHike routeHike)
        {
            db.SaveChanges();
        }
        public static RouteHike GetRouteHikeByHikeID(int hikeID)
        {
            return db.RouteHike.Where(rh => rh.Hike.ID == hikeID).FirstOrDefault();
        }
    }

    
}

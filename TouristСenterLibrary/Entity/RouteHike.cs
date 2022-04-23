using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class RouteHike
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public Transport StartBus { get; set; }
        [Required] public Transport FinishBus { get; set;}
        [Required] public Hike Hike { get; set; }

        public RouteHike()
        {

        }

        public RouteHike(Route Route, Transport StartBus, Transport FinishBus, Hike Hike)
        {
            this.Route = Route;
            this.StartBus = StartBus;
            this.FinishBus = FinishBus;
            this.Hike = Hike;
        }


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
            var routeHike = db.RouteHike
                .Include(r=>r.StartBus)
                .Include(r => r.FinishBus)
                .Include(r => r.Hike)
                .Include(r => r.Route)
                .Where(rh => rh.Hike.ID == hikeID).FirstOrDefault();
            return routeHike;
        }
    }

    
}

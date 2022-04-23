using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class RouteHike
    {
        private static ApplicationContext db = ContextManager.db;
        private static NpgsqlConnection npgsql = ContextManager.npgsql;
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


        public static bool Add(RouteHike routeHike)
        {
            //db.RouteHike.Add(routeHike);
            //db.SaveChanges();
            var command = new NpgsqlCommand("INSERT INTO \"RouteHike\" (\"RouteID\",\"StartBusID\",\"FinishBusID\",\"HikeID\") VALUES " +
                                            "(@routeId, @startBusId, @finishBusId, @hikeId)", npgsql);
            NpgsqlParameter routeParam = new NpgsqlParameter("@routeId", routeHike.Route.ID);
            NpgsqlParameter startParam = new NpgsqlParameter("@startBusId", routeHike.StartBus.ID);
            NpgsqlParameter finishParam = new NpgsqlParameter("@finishBusId", routeHike.FinishBus.ID);
            NpgsqlParameter hikeParam = new NpgsqlParameter("@hikeId", routeHike.Hike.ID);
            command.Parameters.Add(routeParam);
            command.Parameters.Add(startParam);
            command.Parameters.Add(finishParam);
            command.Parameters.Add(hikeParam);
            var query = command.ExecuteNonQuery();
            db.Entry(routeHike).Reload();
            return query > 0;

        }
        public static bool UpdateTransport(RouteHike routeHike, int startBusId, int finishBusId)
        {
            var command = new NpgsqlCommand("UPDATE \"RouteHike\" SET " +
                                            "\"StartBusID\" = @startBusId, \"FinishBusID\" = @finishBusId " +
                                            "WHERE \"ID\" = @routeHikeId", npgsql);
            NpgsqlParameter startParam = new NpgsqlParameter("@startBusId", startBusId);
            NpgsqlParameter finishParam = new NpgsqlParameter("@finishBusId", finishBusId);
            NpgsqlParameter routeHikeParam = new NpgsqlParameter("@routeHikeId", routeHike.ID); 
            command.Parameters.Add(startParam);
            command.Parameters.Add(finishParam);
            command.Parameters.Add(routeHikeParam);           
            var query = command.ExecuteNonQuery();
            db.Entry(routeHike).Reload();
            return query > 0;                  
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

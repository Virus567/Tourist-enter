using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Route
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int NumberDays { get; set; }
        [Required] public string Description { get; set; }
        public string FullDescription { get; set; }
        [Required] public CheckpointRoute CheckpointStart { get; set; }
        public int CheckpointStartID { get; set; }
        [Required] public CheckpointRoute CheckpointFinish { get; set; }
        public int CheckpointFinishID { get; set; }
        [Required] public string River { get; set; }
        [Required] public string[] Images { get; set; }
        [Required] public int Popularity { get; set; }

        public Route()
        {

        }
        public Route(string Name, int NumberDays, string Description)
        {
            this.Name = Name;
            this.NumberDays = NumberDays;
            this.Description = Description;
        }

        public bool Update()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static List<Route> GetRouters()
        {
            try
            {
                return db.Route.Include(r => r.CheckpointStart).Include(r => r.CheckpointFinish).ToList();
            }
            catch (Exception ex)
            {
                return new List<Route>();
            }
            
        }

        public static Route? GetRouteByID(int id)
        {
            try
            {
                return db.Route.Include(r => r.CheckpointStart).Include(r => r.CheckpointFinish).FirstOrDefault(r => r.ID == id);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public static List<string> GetNameRoute()
        {
             return db.Route.Select(x => x.Name).ToList();
        }
        public static int GetDaysAmountByRouteName(string routeName)
        {
            Route route = db.Route.Where(r => r.Name == routeName).FirstOrDefault();
            return route.NumberDays;
        }
        public static Route GetRouteByRouteName(string routeName)
        {
            return db.Route.Where(r=>r.Name == routeName).FirstOrDefault();
        }
    }
}

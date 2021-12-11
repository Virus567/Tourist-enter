using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Route
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int NumberDays { get; set; }
        [Required] public List<CheckpointRoute> Checkpoints { get; set; } = new List<CheckpointRoute>();
        public static List<string> GetNameRoute()
        {
            using (var db = new ApplicationContext())
            {
                return db.Route.Select(x => x.Name).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class ApplicationType
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Name { get; set; }

        public static ApplicationType GetTeamType()
        {
            return db.ApplicationType.Where(a => a.ID == 2).ToList()[0];
        }
        public static ApplicationType GetFamilyType()
        {
            return db.ApplicationType.Where(a => a.ID == 1).ToList()[0];
        }
    }

}

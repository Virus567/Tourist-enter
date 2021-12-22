using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class CountableEquipment //Измеримое снаряжение 
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Number { get; set; }

        public static int GetEquipmentAmount(int cEquipId)
        {
            return db.CountableEquipment.Where(ce => ce.ID == cEquipId).Select(e => e.Number).ToList()[0];
        }
    }
}

 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Equipment
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime PurchaseDate { get; set; }
        [Required] public string Type { get; set; }
        public List<Hike> HikesList { get; set; }

        public Equipment()
        {
            HikesList = new List<Hike>();
        }
        public Equipment(string Name, DateTime PurchaseDate, string Type)
        {
            this.Name = Name;
            this.PurchaseDate = PurchaseDate;
            this.Type = Type;
            HikesList = new List<Hike>();
        }

        public static List<Equipment> GetDefaultEquipment(int peopleAmount)
        {
            int countTable;
            if (peopleAmount < 10) countTable = 1;
            else countTable = peopleAmount / 10;
            List<Equipment> tables = db.Equipment.Where(e => e.Type == "table").Take(countTable).ToList();
            int countPavilions;
            if (peopleAmount < 15) countPavilions = 1;
            else countPavilions = peopleAmount / 15;
            List<Equipment> pavilions = db.Equipment.Where(e => e.Type == "pavilion").Take(countPavilions).ToList();
            int countAxes;
            if (peopleAmount < 12) countAxes = 1;
            else countAxes = peopleAmount / 12;
            List<Equipment> axes = db.Equipment.Where(e => e.Type == "ax").Take(countAxes).ToList();
            List<Equipment> result = tables;
            result.AddRange(pavilions);
            result.AddRange(axes);
            return result;
        }

        public static List<Equipment> GetKayaks(int peopleAmount)
        {
            if(peopleAmount % 2 == 0)
            {
                List<Equipment> kayaks2 = db.Equipment.Where(e => e.Type == "kayak2").Take(peopleAmount/2).ToList();
                return kayaks2;
            }
            else
            {
                List<Equipment> kayaks2 = db.Equipment.Where(e => e.Type == "kayak2").Take((peopleAmount-3) / 2).ToList();
                List<Equipment> kayaks3 = db.Equipment.Where(e => e.Type == "kayak3").Take(1).ToList();
                kayaks2.AddRange(kayaks3);
                return kayaks2;
            }

        }
        public static List<Equipment> GetRafts(int peopleAmount)
        {
            int countRafts = (peopleAmount / 8) + 1;
            List<Equipment> rafts = db.Equipment.Where(e => e.Type == "raft").Take(countRafts).ToList();
            return rafts;
        }

    }
}

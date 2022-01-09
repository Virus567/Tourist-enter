using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class CountableHikeEquipment
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual CountableEquipment CountableEquipment { get; set; }
        [Required] public int Number { get; set; }
        [Required] public virtual Hike Hike { get; set; }
        public CountableHikeEquipment()
        {
        }

        public CountableHikeEquipment(CountableEquipment equip, int number)
        {
            CountableEquipment = equip;
            Number = number;
        }
        public static List<CountableHikeEquipment> GetDefaultEquipment(int peopleAmount, int tentsAmount, int hermeticBagAmount)
        {
            List<CountableHikeEquipment> equipments = new List<CountableHikeEquipment>();
            int peopleAmountWithOutTentsAmount = peopleAmount - tentsAmount;
            int peopleAmountWithOuthermeticBagAmount = peopleAmount - hermeticBagAmount;

            CountableEquipment mat = db.CountableEquipment.Where(e => e.Name == "Коврик").FirstOrDefault();
            CountableHikeEquipment hikeMat = new CountableHikeEquipment(mat, peopleAmount);
            equipments.Add(hikeMat);

            CountableEquipment sleepingBag = db.CountableEquipment.Where(e => e.Name == "Спальник").FirstOrDefault();
            CountableHikeEquipment hikeSleepingBag = new CountableHikeEquipment(sleepingBag, peopleAmount);
            equipments.Add(hikeSleepingBag);

            CountableEquipment canister = db.CountableEquipment.Where(e => e.Name == "Канистра").FirstOrDefault();
            CountableHikeEquipment hikeCanister = new CountableHikeEquipment(canister, (peopleAmount / 3) + 1);
            equipments.Add(hikeCanister);

            CountableEquipment lair4 = db.CountableEquipment.Where(e => e.Name == "Палатка Lair4").FirstOrDefault();
            CountableEquipment lair3 = db.CountableEquipment.Where(e => e.Name == "Палатка Lair3").FirstOrDefault();
            if (peopleAmountWithOutTentsAmount % 4 == 0)
            {
                CountableHikeEquipment hikeLair4 = new CountableHikeEquipment(lair4, peopleAmountWithOutTentsAmount / 4);
                equipments.Add(hikeLair4);
            }
            else
            {
                CountableHikeEquipment hikeLair4 = new CountableHikeEquipment(lair4, peopleAmountWithOutTentsAmount / 4);
                CountableHikeEquipment hikeLair3 = new CountableHikeEquipment(lair3, 1);
                equipments.Add(hikeLair4);
                equipments.Add(hikeLair3);
            }

            CountableEquipment lair2 = db.CountableEquipment.Where(e => e.Name == "Палатка Lair2").FirstOrDefault();
            CountableHikeEquipment hikeLair2 = new CountableHikeEquipment(lair2, tentsAmount);
            equipments.Add(hikeLair2);

            CountableEquipment pot10l = db.CountableEquipment.Where(e => e.Name == "Котелок 10л").FirstOrDefault();
            CountableHikeEquipment hikePot10l = new CountableHikeEquipment(pot10l, (peopleAmount / 10) + 1);
            equipments.Add(hikePot10l);

            CountableEquipment pot8l = db.CountableEquipment.Where(e => e.Name == "Котелок 8л").FirstOrDefault();
            CountableHikeEquipment hikePot8l = new CountableHikeEquipment(pot8l, 1);
            equipments.Add(hikePot8l);

            CountableEquipment campfireStands = db.CountableEquipment.Where(e => e.Name == "Костровые стойки").FirstOrDefault();
            CountableHikeEquipment hikeCampfireStands = new CountableHikeEquipment(campfireStands, (peopleAmount / 30) + 1);
            equipments.Add(hikeCampfireStands);

            CountableEquipment hermeticBag = db.CountableEquipment.Where(e => e.Name == "Гермомешок").FirstOrDefault();
            CountableHikeEquipment hikeHermeticBag =
                new CountableHikeEquipment(hermeticBag, (peopleAmountWithOuthermeticBagAmount / 2) + hermeticBagAmount + 1);
            equipments.Add(hikeHermeticBag);

            return equipments;
        }

        public static CountableHikeEquipment GetPaddle(int peopleAmount)
        {
            CountableEquipment paddle = db.CountableEquipment.Where(e => e.Name == "Весло").FirstOrDefault();
            CountableHikeEquipment hikePaddle = new CountableHikeEquipment(paddle, peopleAmount);
            return hikePaddle;
        }
    }
}

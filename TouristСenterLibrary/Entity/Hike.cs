using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class Hike
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public string Status { get; set; }
        public List<Order> OrdersList { get; set; }
        public List<CountableHikeEquipment> CountableHikeEquipList { get; set; }
        public List<Equipment> EquipmentsList { get; set; }
        public Hike()
        {
            OrdersList = new List<Order>();
            CountableHikeEquipList = new List<CountableHikeEquipment>();
            EquipmentsList = new List<Equipment>();
        }
        public Hike(Route Route,string Status)
        {
            this.Route = Route;
            this.Status = Status;
            OrdersList = new List<Order>();
            CountableHikeEquipList = new List<CountableHikeEquipment>();
            EquipmentsList = new List<Equipment>();
        }

        public enum EnumStatus
        {
            [Description("В сборке")] inAssembly = 1,
            [Description("На маршруте")] onRoute = 2,
            [Description("Завершен")] сompleted = 3,
            [Description("Отменен")] canceled = 4
        }

        public static void Add(Hike hike)
        {
            db.Hike.Add(hike);
            db.SaveChanges();
        }
        public static void Update(Hike hike)
        {
            db.Hike.Update(hike);
            db.SaveChanges();
        }

        public static Hike GetHikeByID(int hikeId)
        {
            return db.Hike.Where(h => h.ID == hikeId).First();
        }


        public class HikeView
        {
            public int ID { get; set; }
            public List<Order> OrdersList { get; set; }
            public List<User> Users { get; set; } = new List<User>();
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string RouteName { get; set; }
            public string WayToTravel { get; set; }
            public string CompanyName { get; set; }
            public int PeopleAmount { get; set; }
            public string Status { get; set; }
            public bool IsPhotograph { get; set; }
        }

        public static List<HikeView> GetView()
        {
            var hikeList = db.Hike.Select(h => new HikeView()
            {
                ID = h.ID,
                OrdersList = h.OrdersList,
                RouteName = h.Route.Name,
                WayToTravel = h.OrdersList.FirstOrDefault().WayToTravel,
                CompanyName = h.OrdersList.FirstOrDefault().TouristGroup.GetCompanyNameForHike(),
                StartTime = h.OrdersList.FirstOrDefault().StartTime.ToString("d"),
                FinishTime = h.OrdersList.FirstOrDefault().FinishTime.ToString("d"),
                Status = h.Status
            }).ToList();

            foreach (HikeView hike in hikeList)
            {
                hike.PeopleAmount = 0;
                foreach(var order in hike.OrdersList)
                {
                    hike.PeopleAmount += order.TouristGroup.PeopleAmount;
                }
            }
            
            return hikeList;
        }

        public static List<HikeView> GetViewByUserID(int userId)
        {
            try
            {
                var hikeList = db.Hike.Include(h=>h.OrdersList)
                            .ThenInclude(h => h.TouristGroup)
                            .ThenInclude(h => h.User )
                            .Include(h => h.OrdersList)
                            .ThenInclude(h => h.TouristGroup)
                            .ThenInclude(h => h.ParticipantsList) 
                            .ThenInclude(h=>h.User)
                            .Select(h => new HikeView()
                        {
                            ID = h.ID,
                            OrdersList = h.OrdersList,
                            RouteName = h.Route.Name,
                            WayToTravel = h.OrdersList.FirstOrDefault().WayToTravel,
                            CompanyName = h.OrdersList.FirstOrDefault().TouristGroup.GetCompanyNameForHike(),
                            StartTime = h.OrdersList.FirstOrDefault().StartTime.ToString("d"),
                            FinishTime = h.OrdersList.FirstOrDefault().FinishTime.ToString("d"),
                            Status = h.Status
                        }).ToList();

                        foreach (HikeView hike in hikeList)
                        {
                            hike.PeopleAmount = 0;
                            foreach (var order in hike.OrdersList)
                            {
                                hike.PeopleAmount += order.TouristGroup.PeopleAmount;
                                hike.Users.Add(order.TouristGroup.User);
                                foreach (var participant in order.TouristGroup.ParticipantsList)
                                {
                                    var p = participant;
                                    p.TouristGroup = null;
                                    hike.Users.Add(p.User);
                                }
                            }
                        }
                        hikeList = hikeList.Where(h => h.Users.Contains(User.GetUserByID(userId))).ToList();
                        return hikeList;
            }
            catch (Exception ex)
            {
                return new List<HikeView>();
            }
           
        }

        public static HikeView? GetViewByID(int hikeId)
        {
            try
            {
                var hike = db.Hike.Include(h => h.OrdersList)
                            .ThenInclude(h => h.TouristGroup)
                            .ThenInclude(h => h.User)
                            .Include(h => h.OrdersList)
                            .ThenInclude(h => h.TouristGroup)
                            .ThenInclude(h => h.ParticipantsList)
                            .ThenInclude(h=>h.User)
                            .Where(h=>h.ID == hikeId)
                            .Select(h => new HikeView()
                            {
                                ID = h.ID,
                                OrdersList = h.OrdersList,
                                RouteName = h.Route.Name,
                                WayToTravel = h.OrdersList.FirstOrDefault().WayToTravel,
                                CompanyName = h.OrdersList.FirstOrDefault().TouristGroup.GetCompanyNameForHike(),
                                StartTime = h.OrdersList.FirstOrDefault().StartTime.ToString("d"),
                                FinishTime = h.OrdersList.FirstOrDefault().FinishTime.ToString("d"),
                                Status = h.Status
                            }).FirstOrDefault();
                    if (hike != null)
                    {
                        hike.PeopleAmount = 0;
                        foreach (var order in hike.OrdersList)
                        {
                            hike.PeopleAmount += order.TouristGroup.PeopleAmount;
                            foreach (var participant in order.TouristGroup.ParticipantsList)
                            {
                                participant.TouristGroup = null;
                                hike.Users.Add(participant.User);
                            }
                        }
                    }            
                return hike;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public class HikeViewAll
        {
            public int ID { get; set; }
            public List<Order> OrdersList { get; set; }
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

        public static void SetEquipmentForHike(Hike hike)
        {
            int peopleAmount = GetPeopleAmountOfHike(hike.ID);
            int individualTentsAmount = Hike.GetIndividualTentsAmount(hike);
            int hermeticBagsAmount = Hike.GetHermeticBagsAmount(hike);
            hike.EquipmentsList.AddRange(Equipment.GetDefaultEquipment(peopleAmount));
            hike.CountableHikeEquipList.AddRange(CountableHikeEquipment.GetDefaultEquipment(peopleAmount, individualTentsAmount, hermeticBagsAmount));
            if(hike.OrdersList.FirstOrDefault().WayToTravel == "Байдарки")
            {
                hike.EquipmentsList.AddRange(Equipment.GetKayaks(peopleAmount));
            }
            else
            {
                hike.EquipmentsList.AddRange(Equipment.GetRafts(peopleAmount));
                hike.CountableHikeEquipList.Add(CountableHikeEquipment.GetPaddle(peopleAmount));
            }
        }

        public static List<HikeViewAll> GetViewAllByID(int hikeID)
        {
            List<HikeViewAll>list = db.Hike
                .Include(h => h.OrdersList)
                .Include(h => h.Route)
                .Where(h=>h.ID == hikeID).Select(h => new HikeViewAll()
            {
                ID = hikeID,
                OrdersList = h.OrdersList,
                StartTime = h.OrdersList.FirstOrDefault().StartTime.ToString("d"),
                FinishTime = h.OrdersList.FirstOrDefault().FinishTime.ToString("d"),
                RouteName = h.Route.Name,
                WayToTravel = h.OrdersList.FirstOrDefault().WayToTravel,
                CompanyName = h.OrdersList.FirstOrDefault().TouristGroup.GetCompanyNameForHike(),
                Status = h.Status
            }).ToList();
            foreach (HikeViewAll hv in list)
            {
                hv.PeopleAmount = 0;
                hv.HermeticBagAmount = 0;
                hv.IndividualTentAmount = 0;
                hv.ChildrenAmount = 0;
                foreach (var order in hv.OrdersList)
                {
                    hv.PeopleAmount += order.TouristGroup.PeopleAmount;
                    hv.HermeticBagAmount += order.HermeticBagAmount;
                    hv.IndividualTentAmount += order.IndividualTentAmount;
                    hv.ChildrenAmount += order.TouristGroup.ChildrenAmount;
                }
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

        public static int GetIndividualTentsAmount(Hike hike)
        {
            int count = 0;
            foreach(var order in hike.OrdersList)
            {
                count += order.IndividualTentAmount;
            }
            return count;
        }
        public static int GetHermeticBagsAmount(Hike hike)
        {
            int count = 0;
            foreach (var order in hike.OrdersList)
            {
                count += order.HermeticBagAmount;
            }
            return count;
        }
        public static List<string> GetPossibleStatuses(string str)
        {
            EnumStatus startStatus = GetEnumByDescription<EnumStatus>(str);
            List<string> list = new List<string>();
            foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
            {
                if (status >= startStatus )
                {
                    list.Add(GetDescriptionByEnum(status));
                }
            }
            return list;
        }
        public static string GetDescriptionByEnum(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Enum is not found!", nameof(description));
        }

    }
}

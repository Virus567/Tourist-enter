using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class TouristGroup
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public int PeopleAmount { get; set; }
        [Required] public int ChildrenAmount { get; set; }
        [Required] public User User { get; set; }
        public List<Participant> ParticipantsList { get; set; }

        public TouristGroup()
        {
            ParticipantsList = new List<Participant>();
        }
        public TouristGroup(User User, int PeopleAmount,int ChildrenAmount)
        {
            this.User = User;
            this.PeopleAmount = PeopleAmount;
            this.ChildrenAmount = ChildrenAmount;
            ParticipantsList = new List<Participant>();
        }

        public  string GetFullName()
        {
            return User.GetFullName();
        }
        public static void Add(TouristGroup client)
        {
            db.TouristGroup.Add(client);
            db.SaveChanges();
        }
        public static void Update(TouristGroup client)
        {
            db.TouristGroup.Update(client);
            db.SaveChanges();
        }
        public string GetCompanyNameForHike()
        {
            return User.GetCompanyNameForHike();
        }
        public string GetCompanyNameForOrder()
        {
            return User.GetCompanyNameForOrder();
        }


        public static TouristGroup GetGroupByID(int groupId)
        {
            var client = db.TouristGroup.Where(c => c.ID == groupId).FirstOrDefault();
            db.Participant.Where(p => p.TouristGroupID == groupId).Load();
            return client;
        }
        public static TouristGroup GetGroupByOrderId(int orderId)
        {
            return (from c in db.TouristGroup
                    join o in db.Order on c.ID equals o.TouristGroup.ID
                    where o.ID == orderId
                    select c).FirstOrDefault();
        }
    }
}

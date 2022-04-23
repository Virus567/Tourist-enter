using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace TouristСenterLibrary.Entity
{
    public class Participant
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public  TouristGroup TouristGroup { get; set; }
        [Required] public int TouristGroupID { get; set; }
        [Required] public User User { get; set; }
        [Required] public bool InGroup { get; set; }
        [Required] public bool IsActive { get; set; }

        public Participant()
        {
        }
        public Participant(User User, bool InGroup, bool IsActive)
        {
            this.User = User;
            this.InGroup = InGroup;
            this.IsActive = IsActive;
        }
        public static List<Participant> GetParticipantsByHike(int hikeID)
        {
            return (from p in db.Participant                   
                    join c in db.TouristGroup on p.TouristGroup.ID equals c.ID
                    join o in db.Order on  c.ID equals o.TouristGroup.ID
                    join h in db.Hike on o.Hike.ID equals h.ID
                    where h.ID == hikeID
                    select p).Include(p => p.User).ToList();

        }
        public static bool IsParticipantsForOrder(TouristGroup group)
        {
            List<Participant> participants = db.Participant.Include(p => p.TouristGroup).Include(p=>p.User).ToList();
            participants = participants.Where(p => p.TouristGroup.ID == group.ID).ToList();
            if (participants.Count == group.PeopleAmount)
            {
                return true;
            }
            return false;
        }
        public static List<Participant> GetParticipantsByOrder(int orderId)
        {
            return (from p in db.Participant
                    join c in db.TouristGroup on p.TouristGroup.ID equals c.ID
                    join o in db.Order on c.ID equals o.TouristGroup.ID
                    where o.ID == orderId
                    select p).Include(p => p.User).ToList();

        }
    }
}

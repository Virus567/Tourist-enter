using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace TouristСenterLibrary.Entity
{
    public class Participant : Human
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual Client Client { get; set; }

        public Participant()
        {

        }
        public Participant(string Surname, string Name,string Middlename, string PhoneNumber) : base(Surname, Name, Middlename, PhoneNumber)
        {

        }
        public Participant(string Surname, string Name, string PhoneNumber) : base(Surname, Name, PhoneNumber)
        {

        }
        public static List<Participant> GetParticipantsByHike(int hikeID)
        {
            return (from p in db.Participant                   
                    join c in db.Client on p.Client.ID equals c.ID
                    join o in db.Order on  c.ID equals o.Client.ID
                    join h in db.Hike on o.Hike.ID equals h.ID
                    where h.ID == hikeID
                    select p).ToList();

        }
        public static bool IsParticipantsForOrder(Client client)
        {
            List<Participant> participants = db.Participant.ToList();
            participants = participants.Where(p => p.Client.ID == client.ID).ToList();
            if (participants.Count == client.PeopleAmount)
            {
                return true;
            }
            return false;
        }
        public static List<Participant> GetParticipantsByOrder(int orderId)
        {
            return (from p in db.Participant
                    join c in db.Client on p.Client.ID equals c.ID
                    join o in db.Order on c.ID equals o.Client.ID
                    where o.ID == orderId
                    select p).ToList();

        }
    }
}

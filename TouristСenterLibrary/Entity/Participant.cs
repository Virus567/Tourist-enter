using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;


namespace TouristСenterLibrary.Entity
{
    public class Participant
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string Middlename { get; set; }
        [MaxLength(15)]
        [Required] public string ClientTelefonNumber { get; set; }
        [Required] public Client Client { get; set; }
        

        public static List<Participant> GetParticipants()
        {
             return db.Participant.ToList();
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
        public static bool IsParticipantForOrder(int clientId)
        {
            try
            {
                List<Participant> participants = db.Participant.Where(p => p.Client.ID == clientId).ToList();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public static List<Participant> GetParticipantsByOrder(int orderId)
        {
            return (from p in db.Participant
                    join c in db.Client on p.Client.ID equals c.ID
                    join o in db.Order on c.ID equals o.Client.ID
                    where o.ID == orderId
                    select p).ToList();

        }
        public static List<string> GetAllName(List<Participant> participants)
        {
            List<string> list = new List<string>();
            foreach(Participant p in participants)
            {
                string tmp = $"{p.Surname} {p.Name}";
                if (p.Middlename != null) tmp += $" {p.Middlename}";
                list.Add(tmp);
            }
            return list;
        }
    }
}

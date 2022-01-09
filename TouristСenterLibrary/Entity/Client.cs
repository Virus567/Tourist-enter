using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Client : Human
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        public string? NameOfCompany { get; set; }
        [Required] public int PeopleAmount { get; set; }
        [Required] public int ChildrenAmount { get; set; }
        public virtual List<Participant> ParticipantsList { get; set; } = new List<Participant>();

        public Client()
        {

        }
        public Client(string NameOfCompany,string Surname,string Name, string Middlename,
                      string PhoneNumber,int PeopleAmount,int ChildrenAmount) : base(Surname, Name,Middlename, PhoneNumber)
        {
            this.NameOfCompany = NameOfCompany;
            this.PeopleAmount = PeopleAmount;
            this.ChildrenAmount = ChildrenAmount;
        }
        public Client(string? NameOfCompany, string Surname, string Name,
                      string PhoneNumber, int PeopleAmount, int ChildrenAmount) : base(Surname, Name, PhoneNumber)
        {
            this.NameOfCompany = NameOfCompany;
            this.PeopleAmount = PeopleAmount;
            this.ChildrenAmount = ChildrenAmount;
        }

        public static void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }

        public static void Update(Client client)
        {
            db.Client.Update(client);
            db.SaveChanges();
        }

        public string GetCompanyNameForHike()
        {
            string tmp;
            if (NameOfCompany != null)
                tmp = $"{NameOfCompany}";
            else
            {
                tmp = "Сборная";
            }                
            return tmp;
        }
        public string GetCompanyNameForOrder()
        {
            string tmp;
            if (NameOfCompany != null)
                tmp = $"{NameOfCompany}";
            else
            {
                tmp = $"{Surname} {Name.Substring(0, 1)}.";
                if (Middlename != null) tmp += $" {Middlename.Substring(0, 1)}.";
            }
            return tmp;
        }
        public static Client GetClientByID( int clientId)
        {
            return db.Client.Where(c => c.ID == clientId).FirstOrDefault();
        }
    }
}

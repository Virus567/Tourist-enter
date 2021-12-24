using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Client 
    {
        
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        public string NameOfCompany { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string Middlename { get; set; }
        [MaxLength(15)]
        [Required] public string ClientTelefonNumber { get; set; }
        [Required] public int PeopleAmount { get; set; }

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
        public string GetFullNameOrCompanyName()
        {

            string tmp;
            if (NameOfCompany != null)
                tmp = $"{NameOfCompany}";
            else
            {
                tmp = $"{Surname} {Name}";
                if (Middlename != null) tmp += $" {Middlename}";
            }
            return tmp;
        }
        public static Client GetClientByID( int clientId)
        {
            return db.Client.Where(c => c.ID == clientId).FirstOrDefault();
        }
        
        public static List<Client> GetClientsByHikeID(int hikeId)
        {
            return(from c in db.Client
                   join o in db.Order on c.ID equals o.Client.ID
                   where o.Hike.ID == hikeId
                   select c).ToList();
            
        }
    
    }
}

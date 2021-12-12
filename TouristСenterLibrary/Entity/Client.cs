using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class Client 
    {
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
        public int GetPeopleAmountOfHike(int hikeID)
        {
            int tmp = 0;
            List<Hike.HikeViewAll> list = Hike.GetViewAll(hikeID);
            foreach (Hike.HikeViewAll l in list)
            {
                tmp += l.PeopleAmount;
            }
            return tmp;
        }
    }
}

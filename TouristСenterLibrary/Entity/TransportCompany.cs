using System.ComponentModel.DataAnnotations;

namespace TouristСenterLibrary.Entity
{
    public class TransportCompany
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [MaxLength(15)]
        [Required] public string CompanyTelefonNumber { get; set; }

        public TransportCompany()
        {

        }
        public TransportCompany(string Name, string CompanyTelefonNumber)
        {
            this.Name = Name;
            this.CompanyTelefonNumber = CompanyTelefonNumber;
        }
    }
}

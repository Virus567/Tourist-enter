using System.ComponentModel.DataAnnotations;

namespace TouristСenterLibrary.Entity
{
    public class TransportCompany
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [MaxLength(15)] [Required] public string PhoneNumber { get; set; }

        public TransportCompany()
        {

        }
        public TransportCompany(string Name, string PhoneNumber)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }
    }
}

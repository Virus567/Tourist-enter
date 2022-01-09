using System.ComponentModel.DataAnnotations;

namespace TouristСenterLibrary.Entity
{
    public class CountableEquipment 
    {      
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Number { get; set; }
        public CountableEquipment()
        {

        }

        public CountableEquipment(string Name, int Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
    }
}

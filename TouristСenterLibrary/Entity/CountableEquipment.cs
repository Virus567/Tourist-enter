using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class CountableEquipment //Измеримое снаряжение 
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Number { get; set; }
    }
}

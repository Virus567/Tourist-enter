using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class Food // Питание
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
    }
}

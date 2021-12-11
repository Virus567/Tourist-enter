 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class Equipment
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime PurchaseDate { get; set; }

    }
}

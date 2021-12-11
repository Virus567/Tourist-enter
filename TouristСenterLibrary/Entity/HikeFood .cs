using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class HikeFood
    {
        public int ID { get; set; }
        [Required] public Food Food { get; set; }
        [Required] public int  Number { get; set; }
        [Required] public string Unit { get; set; }
        [Required] public DateTime ShelfLife { get; set; }
        [Required] public Hike Hike { get; set; }
    }
}

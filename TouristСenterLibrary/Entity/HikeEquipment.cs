using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class HikeEquipment
    {
        public int ID { get; set; }
        [Required] public virtual Equipment Equipment { get; set; }
        [Required] public virtual Hike Hike { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class CountableHikeEquip
    {
        public int ID { get; set; }
        [Required] public virtual CountableEquipment Equipment { get; set; }
        [Required] public int Number { get; set; }
        [Required] public virtual Hike Hike { get; set; }
    }
}

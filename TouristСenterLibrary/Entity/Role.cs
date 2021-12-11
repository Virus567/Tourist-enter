using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class Role
    {
        public int ID { get; set; }
        [Required] public string PositionName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class ApplicationType
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
    }
}

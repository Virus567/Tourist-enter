using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class CheckpointRoute
    {
        public int ID { get; set; }
        [Required] public string  Name { get; set; }
        [Required] public string TargetStop { get; set; }

    }
}

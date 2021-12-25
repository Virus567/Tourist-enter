using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class RouteHike
    {
        public int ID { get; set; }
        [Required] public virtual Route Route { get; set; }
        [Required] public virtual CheckpointRoute Start { get; set; }
        [Required] public virtual CheckpointRoute Finish { get; set; }
        [Required] public virtual Transport StartBus { get; set; }
        [Required] public virtual Transport FinishBus { get; set;}
        [Required] public virtual Hike Hike { get; set; }
    }
}

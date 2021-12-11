using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class RouteHike
    {
        public int ID { get; set; }
        [Required] public Route Route { get; set; }
        [Required] public CheckpointRoute Start { get; set; }
        [Required] public CheckpointRoute Finish { get; set; }
        [Required] public CheckpointRoute Halt { get; set; }
        [Required] public Transport StartBus { get; set; }
        [Required] public Transport FinishBus { get; set;}
        [Required] public  DateTime StartTime { get; set; }
        [Required] public DateTime FinishTime { get; set; }
    }
}

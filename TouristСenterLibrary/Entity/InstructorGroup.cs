using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TouristСenterLibrary.Entity;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class InstructorGroup
    {
        public int ID { get; set; }
        [Required] public Instructor Instructor{ get; set; }
        [Required] public Hike Hike { get; set; }

        public static List<InstructorGroup> GetInstructorGroup(int hikeId)
        {
            using (var db = new ApplicationContext())
            {
                return (from i in db.InstructorGroup
                        where i.Hike.ID == hikeId
                        select new InstructorGroup()
                        {
                            ID = i.ID,
                            Instructor = i.Instructor,
                            Hike = i.Hike
                        }).ToList();
            }
        }
    }
    
}

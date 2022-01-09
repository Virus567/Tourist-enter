using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class InstructorGroup
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual List<Instructor> InstructorsList { get; set; } = new List<Instructor>();
        [Required] public virtual Hike Hike { get; set; }

        public static void Add(InstructorGroup instructorGroup)
        {
            db.InstructorGroup.Add(instructorGroup);
            db.SaveChanges();
        }

        public static void Update(InstructorGroup instructorGroup)
        {
            db.SaveChanges();
        }     

        public static InstructorGroup GetInstructorGroupByHikeID(int hikeId)
        {
            return (from i in db.InstructorGroup
                    where i.Hike.ID == hikeId
                    select i).FirstOrDefault();
        }
    }
    
}

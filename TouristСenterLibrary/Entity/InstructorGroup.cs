using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class InstructorGroup
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        public List<Instructor> InstructorsList { get; set; }
        [Required] public virtual Hike Hike { get; set; }

        public InstructorGroup()
        {
            InstructorsList = new List<Instructor>();
        }

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
            var instructorGroup = db.InstructorGroup
                .Include(i => i.Hike)
                .Include(i => i.InstructorsList)
                .Where(i => i.Hike.ID == hikeId).FirstOrDefault();
            return instructorGroup;
        }
    }
    
}

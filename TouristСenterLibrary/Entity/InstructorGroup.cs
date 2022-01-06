using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TouristСenterLibrary.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class InstructorGroup
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public virtual Instructor Instructor{ get; set; }
        [Required] public virtual Hike Hike { get; set; }

        public static void Add(InstructorGroup instructorGroup)
        {
            db.InstructorGroup.Add(instructorGroup);
            db.SaveChanges();
        }

        public static void Remove(InstructorGroup instructorGroup)
        {
            db.InstructorGroup.Remove(instructorGroup);
            db.SaveChanges();
        }     

        public static List<InstructorGroup> GetInstructorGroupByHikeID(int hikeId)
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

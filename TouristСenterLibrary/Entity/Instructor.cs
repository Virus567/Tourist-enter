using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Instructor
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string? Middlename { get; set; }
        [Required] public string PassportData { get; set; }
        [MaxLength(15)]
        [Required] public string InstructorTelefonNumber { get; set; }
        [Required] public DateTime EmploymentDate { get; set; }

        public class InstructorView
        {
            public int ID { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Middlename { get; set; }
            public string InstructorTelefonNumber { get; set; }
            public bool InHike { get; set; }
        }
        public static List<InstructorView> GetInstructors()
        {
            return (from i in db.Instructor
                    select new InstructorView()
                    {
                        ID = i.ID,
                        Surname = i.Surname,
                        Name = i.Name,
                        Middlename = i.Middlename,
                        InstructorTelefonNumber = i.InstructorTelefonNumber,
                        InHike = false
                    }).ToList();

        }        
        
        public static List<InstructorView> GetHikeInstructor(int hikeId)
        {
            List<int> intList = new List<int>();
            List<InstructorGroup> listInstructorGroup =InstructorGroup.GetInstructorGroup(hikeId);
            foreach (InstructorGroup ig in listInstructorGroup)
                intList.Add(ig.Instructor.ID);
            List<InstructorView> list = Instructor.GetInstructorsByID(intList);
            return list;
        }

        public static List<string> GetViewHikeInstructor(int hikeId)
        {
            List<InstructorView>list = Instructor.GetHikeInstructor(hikeId);
            string str;
            List<string> strlist = new List<string>();
            foreach(InstructorView i in list)
            {
                str = $"{i.Surname} {i.Name} ";
                if (i.Middlename != null)
                    str += $"{i.Middlename} ";
                str += $"{i.InstructorTelefonNumber}";
                strlist.Add(str);
            }
            return strlist;
        }

        public static List<InstructorView> GetInstructorsByID(List<int> instructorsID)
        {
            List<InstructorView> instructors= new List<InstructorView>();
            foreach(int instructorId in instructorsID)
            {
                instructors.Add((from i in db.Instructor
                    where i.ID == instructorId
                    select new InstructorView()
                    {
                        Surname = i.Surname,
                        Name = i.Name,
                        Middlename = i.Middlename,
                        InstructorTelefonNumber = i.InstructorTelefonNumber

                    }).FirstOrDefault());
            }
            return instructors;
        }
    }
}

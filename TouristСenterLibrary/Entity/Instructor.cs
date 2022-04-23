using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Instructor : Human
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string PassportData { get; set; }
        [Required] public DateTime EmploymentDate { get; set; }
        public List<InstructorGroup> InstructorGroups { get; set; } = new List<InstructorGroup>();

        public Instructor()
        {

        }
        public Instructor(string Surname,string Name,string Middlename, string PassportData, 
                          string PhoneNumber, DateTime EmploymentDate) : base(Surname, Name, Middlename, PhoneNumber)
        {
            this.PassportData = PassportData;
            this.EmploymentDate = EmploymentDate;
        }
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
                        InstructorTelefonNumber = i.PhoneNumber,
                        InHike = false
                    }).ToList();
        }
        
        public static Instructor GetInstructorByID(int id)
        {
            return db.Instructor.Where(i => i.ID == id).FirstOrDefault();
        }
        public static List<InstructorView> GetInstructorViewsByHikeID(int hikeId)
        {
            List<int> intList = new List<int>();
            InstructorGroup instructorGroup =InstructorGroup.GetInstructorGroupByHikeID(hikeId);
            foreach (var ii in instructorGroup.InstructorsList)
            {
                intList.Add(ii.ID);
            }  
            List<InstructorView> list = Instructor.GetInstructorViewsByListID(intList);
            return list;
        }

        public static List<string> GetFullNameInstructorsByHikeID(int hikeId)
        {
            List<InstructorView> list = Instructor.GetInstructorViewsByHikeID(hikeId);
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

        public static List<InstructorView> GetInstructorViewsByListID(List<int> instructorsID)
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
                        InstructorTelefonNumber = i.PhoneNumber

                    }).FirstOrDefault());
            }
            return instructors;
        }
    }
}

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
        public int ID { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string Middlename { get; set; }
        [Required] public string PassportData { get; set; }
        [MaxLength(15)]
        [Required] public string InstructorTelefonNumber { get; set; }
        [Required] public DateTime EmploymentDate { get; set; }

        public class InstructorView
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Middlename { get; set; }
            public string InstructorTelefonNumber { get; set; }
        }
        public static List<InstructorView> GetInstructors()
        {
            using (var db = new ApplicationContext())
            {
                return (from i in db.Instructor
                        select new InstructorView()
                        {
                            Surname = i.Surname,
                            Name = i.Name,
                            Middlename = i.Middlename,
                            InstructorTelefonNumber = i.InstructorTelefonNumber

                        }).ToList();
            }
        }
        
        public static List<string> GetViewInstrucors()
        {
            List<InstructorView> instructors = Instructor.GetInstructors();
            string str;
            List<string> list = new List<string>();
            foreach(InstructorView instructor in instructors)
            {
                str = $"{instructor.Surname} {instructor.Name} ";
                if (instructor.Middlename != null)
                    str += $"{instructor.Middlename} ";
                str += $"{instructor.InstructorTelefonNumber}";
                list.Add(str);
            }
            return list;
        }
        
        public static List<string> GetHikeInstructor(int hikeId)
        {
            List<int> intList = new List<int>();
            List<InstructorGroup> listInstructorGroup =InstructorGroup.GetInstructorGroup(hikeId);
            foreach (InstructorGroup ig in listInstructorGroup)
                intList.Add(ig.Instructor.ID);
            List<string> strList = Instructor.GetViewInstrucorsByID(intList);  
            return strList;
        }

        public static List<List<InstructorView>> GetInstructorsByID(List<int> instructorsID)
        {
            using (var db = new ApplicationContext())
            {
                List<List<InstructorView>> instructors= new List<List<InstructorView>>();
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

                     }).ToList());
                }
                return instructors;
                
            }
        }
        public static List<string> GetViewInstrucorsByID(List<int> instructorsID)
        {
            List<List<InstructorView>> instructors = Instructor.GetInstructorsByID(instructorsID);
            string str;
            List<string> list = new List<string>();
                foreach (List<InstructorView> instructor in instructors)
            {
                for(int j = 0; j < instructor.ToArray().Length; j++)
                {
                    str = $"{instructor[j].Surname} {instructor[j].Name} ";
                    if (instructor[j].Middlename != null)
                        str += $"{instructor[j].Middlename} ";
                    str += $"{instructor[j].InstructorTelefonNumber}";
                    list.Add(str);
                }
            }
            return list;
        }


    }
}

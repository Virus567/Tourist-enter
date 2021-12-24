using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Employee
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string Middlename { get; set; }
        [Required] public string PassportData { get; set; }
        [MaxLength(15)]
        [Required] public string EmployeeTelefonNumber { get; set; }
        [Required] public Role Role { get; set; }
        [Required] public DateTime EmploymentDate { get; set; }

        public static Employee GetEmployeeById(int empId)
        {
            return db.Employee.Where(e => e.ID == empId).FirstOrDefault();
        }
    }
}

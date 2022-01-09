using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Employee
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        public string? Middlename { get; set; }
        [Required] public string PassportData { get; set; }
        [MaxLength(15)]
        [Required] public string EmployeeTelefonNumber { get; set; }
        [Required] public virtual Role Role { get; set; }
        public int RoleID { get; set; }
        [Required] public DateTime EmploymentDate { get; set; }

        public Employee()
        {

        }
        public Employee(string Surname,string Name,string Middlename,string PassportData, string EmployeeTelefonNumber, DateTime EmploymentDate)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Middlename = Middlename;
            this.PassportData = PassportData;
            this.EmployeeTelefonNumber = EmployeeTelefonNumber;
            this.EmploymentDate = EmploymentDate;
        }

        public static Employee GetEmployeeById(int empId)
        {
            return db.Employee.Where(e => e.ID == empId).FirstOrDefault();
        }
    }
}

using System;
using TouristСenterLibrary;
using TouristСenterLibrary.Entity;

namespace gg
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                //db.Employee.Add(new Employee { FirstName = "Санька" , Name = "Алешин" });
                db.SaveChanges();
            }
        }
    }
}

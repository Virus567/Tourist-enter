using System;
using System.Collections.Generic;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class Human
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Middlename { get; set; }
        public string PhoneNumber { get; set; }

        public Human()
        {
        }
        public Human(string Surname, string Name, string PhoneNumber)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }

        public Human(string Surname, string Name, string Middlename, string PhoneNumber)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Middlename = Middlename;
            this.PhoneNumber = PhoneNumber;
        }

        public virtual string GetFullName()
        {
           string fullName = $"{Surname} {Name}";
            if (Middlename != null) fullName += $" {Middlename}";
            return fullName;
        }
    }
}

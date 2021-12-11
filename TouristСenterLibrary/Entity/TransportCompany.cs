using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristСenterLibrary.Entity
{
    public class TransportCompany
    {
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [MaxLength(15)]
        [Required] public string CompanyTelefonNumber { get; set; }
    }
}

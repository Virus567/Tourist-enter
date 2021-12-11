using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Transport
    {
        public int ID { get; set; }
        [MaxLength(6)]
        [Required] public string CarNumber { get; set; }
        [Required] public int SeatCount { get; set; }
        [Required] public TransportCompany TransportCompany { get; set;}

        public class TransportView
        {
            public string CarNumber { get; set; }
            public int SeatCount { get; set; }
            public string TransportCompanyName { get; set; }
        }
        public static List<TransportView> GetTransport()
        {
            using (var db = new ApplicationContext())
            {
                return (from t in db.Transport
                        join tc in db.TransportCompany on t.TransportCompany.ID equals tc.ID
                        select new TransportView()
                        {
                            CarNumber = t.CarNumber,
                            SeatCount = t.SeatCount,
                            TransportCompanyName = tc.Name
                        }).ToList();
            }
        }

    }
}

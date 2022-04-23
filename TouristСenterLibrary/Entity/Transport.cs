using Npgsql;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TouristСenterLibrary.Entity
{
    public class Transport
    {
        private static ApplicationContext db = ContextManager.db;
        private static NpgsqlConnection npgsql = ContextManager.npgsql;
        public int ID { get; set; }
        [MaxLength(6)] [Required] public string CarNumber { get; set; }
        [Required] public int SeatCount { get; set; }
        [Required] public TransportCompany TransportCompany { get; set;}
        [Required] public int TransportCompanyID { get; set; }

        public Transport()
        {

        }
        public Transport(string CarNumber, int SeatCount)
        {
            this.CarNumber = CarNumber;
            this.SeatCount = SeatCount;
        }

        public class TransportView
        {
            public int ID { get; set; }
            public string CarNumber { get; set; }
            public int SeatCount { get; set; }
            public string TransportCompanyName { get; set; }
            public bool IsStartBus { get; set; }
            public bool IsFinishBus { get; set; }
        }
        public static Transport GetTransportByID(int transportId)
        {
            return db.Transport.Where(t => t.ID == transportId).FirstOrDefault();
        }
        public static TransportView GetTransportViewByID(int transportId)
        {
            var command = new NpgsqlCommand("SELECT t.\"ID\", t.\"CarNumber\", t.\"SeatCount\", tc.\"Name\" FROM \"Transport\" AS t " +
                                                    "JOIN \"TransportCompany\" AS tc ON(t.\"TransportCompanyID\" = tc.\"ID\") " +
                                                    "WHERE t.\"ID\" =  @transportId", npgsql);
            NpgsqlParameter transportParam = new NpgsqlParameter("@transportId", transportId);
            command.Parameters.Add(transportParam);

            TransportView transport = new TransportView();
            transport.IsStartBus = false;
            transport.IsFinishBus = false;

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        transport.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        transport.CarNumber = reader.GetString(reader.GetOrdinal("CarNumber"));
                        transport.SeatCount = reader.GetInt32(reader.GetOrdinal("SeatCount"));
                        transport.TransportCompanyName = reader.GetString(reader.GetOrdinal("Name"));
                    }
                }
            }
            return transport;


            //return (from t in db.Transport
            //        join tc in db.TransportCompany on t.TransportCompany.ID equals tc.ID
            //        where t.ID == transportId
            //        select new TransportView()
            //        {
            //            ID = t.ID,
            //            CarNumber = t.CarNumber,
            //            SeatCount = t.SeatCount,
            //            TransportCompanyName = tc.Name,
            //            IsStartBus = false,
            //            IsFinishBus = false
            //        }).FirstOrDefault();
        }

        public static List<TransportView> GetAllTransport()
        {
            return (from t in db.Transport
                    join tc in db.TransportCompany on t.TransportCompany.ID equals tc.ID
                    select new TransportView()
                    {
                        ID = t.ID,
                        CarNumber = t.CarNumber,
                        SeatCount = t.SeatCount,
                        TransportCompanyName = tc.Name,
                        IsStartBus = false,
                        IsFinishBus = false
                    }).ToList();
        }
        public static List<TransportView> GetAllTransportWithStartFinishBuses(int hikeId)
        {
            RouteHike routeHike = RouteHike.GetRouteHikeByHikeID(hikeId);
            List<TransportView> listHikeTransport = GetAllTransport();
            foreach(var l in listHikeTransport)
            {                
                if(l.ID == routeHike.StartBus.ID)
                {
                    l.IsStartBus = true;
                }
                if(l.ID == routeHike.FinishBus.ID)
                {
                    l.IsFinishBus = true;
                }
            }
            return listHikeTransport;
        }
    }
}

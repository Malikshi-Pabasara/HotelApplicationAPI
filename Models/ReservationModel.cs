using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public int PropertyId { get; set; }
        public int RoomId { get; set; }
        public int ContactId { get; set; }
        public string ReservationNo { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string Notes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplication.Data
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey("PropertyInfo")]
        public int PropertyId { get; set; }
        public PropertyInfo PropertyInfo { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("Contacts")]
        public int ContactId { get; set; }
        public Contacts Contacts { get; set; }
        public string ReservationNo { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string Notes { get; set; }

    }
}

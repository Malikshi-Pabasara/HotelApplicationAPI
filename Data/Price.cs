using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Data
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Prices { get; set; }
    }
}

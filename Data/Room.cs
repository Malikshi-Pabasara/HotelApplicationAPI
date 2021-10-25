using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApplication.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

        [ForeignKey("Price")]
        public int PriceId { get; set; }
        public Price Price { get; set; }

        [ForeignKey("PropertyInfo")]
        public int PropertyId { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public bool IsActive { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }
    }
}

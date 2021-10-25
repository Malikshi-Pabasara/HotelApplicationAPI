using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int FeatureId { get; set; }
        public int PriceId { get; set; }
        public int PropertyId { get; set; }
        public bool IsActive { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }
    }
}

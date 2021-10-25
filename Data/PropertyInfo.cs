using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Data
{
    public class PropertyInfo
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace HotelApplication.Data
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string NumberOfFeatures { get; set; }
    }
}

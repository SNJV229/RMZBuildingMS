using System.ComponentModel.DataAnnotations;

namespace RMZBuildingMS.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }

        public List<Facility> Facilities { get; set; }
    }
}

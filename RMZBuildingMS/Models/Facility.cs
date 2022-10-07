using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMZBuildingMS.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }

        [Required]
        public string FacilityName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }  

        public List<Building> Buildings { get; set; }


    }
}

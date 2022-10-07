using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMZBuildingMS.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }

        [Required]
        public string BuildingName { get; set; }

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        List<Floor> Floors { get; set; }

    }
}

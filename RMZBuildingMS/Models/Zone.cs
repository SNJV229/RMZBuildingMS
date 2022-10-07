using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMZBuildingMS.Models
{
    public class Zone
    {
        [Key]
        public string ZoneId { get; set; }

        [Required]
        public decimal ElectricMeter { get; set; }

        public decimal WaterMeter { get; set; }

        [Required]
        public DateTime ReadingDate { get; set; }

        [ForeignKey("Floor")]
        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; } 
        public Building Building { get; set; }

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMZBuildingMS.Models
{
    public class Floor
    {
        [Key]
        public int FloorId { get; set; }

        [Required]
        public string FloorName { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public List<Zone> Zones { get; set; }
    }
}

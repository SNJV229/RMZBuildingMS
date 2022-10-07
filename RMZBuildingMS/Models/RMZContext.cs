using Microsoft.EntityFrameworkCore;

namespace RMZBuildingMS.Models
{
    public class RMZContext : DbContext 
    {
        public RMZContext(DbContextOptions<RMZContext> options) : base(options)
        {
        }

        public DbSet<City> Citys { get; set; } 
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Floor> floors { get; set; }
        public DbSet<Zone> zones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City() { CityId = 01, CityName="Bangalore" },
                new City() { CityId = 02, CityName = "Gurgao" },
                new City() { CityId = 03, CityName = "Delhi" }
                );

            modelBuilder.Entity<Facility>().HasData(
                new Facility() { FacilityId = 01, FacilityName = "WhiteField", CityId = 01 },
                new Facility() { FacilityId = 02, FacilityName = "sector 5", CityId = 02 },
                new Facility() { FacilityId = 03, FacilityName = "hauz kahs", CityId = 03 },
                new Facility() { FacilityId = 04, FacilityName = "Electronic city", CityId = 01 }
                );

            modelBuilder.Entity<Building>().HasData(
                new Building() {  BuildingName = "Building1", BuildingId = 01, FacilityId = 01 },
                new Building() {  BuildingName = "Building2", BuildingId = 02, FacilityId = 02 },
                new Building() {  BuildingName = "Building3", BuildingId = 03, FacilityId = 03 },
                new Building() {  BuildingName = "building4", BuildingId = 04, FacilityId = 04 }
                );

            modelBuilder.Entity<Floor>().HasData(
                new Floor() { FloorName = "Floor1", FloorId = 01, BuildingId = 01 },
                new Floor() { FloorName = "Floor2", FloorId = 02, BuildingId = 02 },
                new Floor() { FloorName = "Floor3", FloorId = 03, BuildingId = 03 },
                new Floor() { FloorName = "Floor4", FloorId = 04, BuildingId = 04 }
                );

            modelBuilder.Entity<Zone>().HasData(
                new Zone() { ZoneId = "Zone1", FloorId = 01, BuildingId = 01, FacilityId = 02, ElectricMeter = 3004, WaterMeter = 298, ReadingDate = DateTime.Parse("2022-06-10") },
                new Zone() { ZoneId = "Zone2", FloorId = 02, BuildingId = 02, FacilityId = 03, ElectricMeter = 2509, WaterMeter = 208, ReadingDate = DateTime.Parse("2022-07-21") },
                new Zone() { ZoneId = "Zone3", FloorId = 03, BuildingId = 03, FacilityId = 01, ElectricMeter = 2507, WaterMeter = 298, ReadingDate = DateTime.Parse("2022-08-13") },
                new Zone() { ZoneId = "Zone4", FloorId = 04, BuildingId = 04, FacilityId = 04, ElectricMeter = 2098, WaterMeter = 098, ReadingDate = DateTime.Parse("2022-09-11") },
                new Zone() { ZoneId = "Zone5", FloorId = 01, BuildingId = 03, FacilityId = 02, ElectricMeter = 2004, WaterMeter = 203, ReadingDate = DateTime.Parse("2022-06-20") },
                new Zone() { ZoneId = "Zone6", FloorId = 02, BuildingId = 02, FacilityId = 01, ElectricMeter = 3549, WaterMeter = 268, ReadingDate = DateTime.Parse("2022-07-17") },
                new Zone() { ZoneId = "Zone7", FloorId = 03, BuildingId = 02, FacilityId = 03, ElectricMeter = 2508, WaterMeter = 283, ReadingDate = DateTime.Parse("2022-08-12") }
                );

        }
    }
}

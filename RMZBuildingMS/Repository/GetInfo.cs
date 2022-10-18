using RMZBuildingMS.Models; 

namespace RMZBuildingMS.Repository
{
    public class GetInfo : IGetInfo
    {
        public readonly RMZContext _context;
        public GetInfo( RMZContext context )
        {
            _context = context;
        }

        public IQueryable getAtLevel(string levelOfInformation, DateTime startDate, DateTime endDate)
        { 
            if (levelOfInformation == "Zone")
            {
                var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                    .Join(_context.floors, z => z.Floor.FloorId, f => f.FloorId, (z, f) => new { f, z })
                    .Join(_context.buildings, bf => bf.f.BuildingId, b => b.BuildingId, (b, bf) => new
                    {
                        facilityName = bf.Facility.FacilityName,
                        buildingName = bf.BuildingName,
                        floorName = b.f.FloorName,
                        zoneName = b.z.ZoneId,
                        zoneElectricreading = b.z.ElectricMeter,
                        zoneWaterreading = b.z.WaterMeter
                    });
                return result;
            }

            else if (levelOfInformation == "Building")
            {
                var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                    .Join(_context.floors, z => z.Floor.FloorId, f => f.FloorId, (z, f) => new { f, z })
                    .Join(_context.buildings, bz => bz.z.BuildingId, bu => bu.BuildingId, (bu, bz) => new
                    {
                        buildingName = bz.BuildingName,
                        electricityBill = bu.z.ElectricMeter,
                        waterBill = bu.z.WaterMeter
                    });
                return result;


            }
            else
            {
                var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                    .Join(_context.floors, z => z.Floor.FloorId, f => f.FloorId, (z, f) => new { f, z })
                    .Join(_context.buildings, bz => bz.z.BuildingId, bu => bu.BuildingId, (bu, bz) => new
                    {
                        facilityName = bu.z.Facility.FacilityName,
                        electricityBill = bu.z.ElectricMeter,
                        waterBill = bu.z.WaterMeter,
                    });
                return result;
            }
        }
    }

}

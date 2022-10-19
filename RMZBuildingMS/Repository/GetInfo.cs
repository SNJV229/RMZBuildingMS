using RMZBuildingMS.Models;
using System.Text.RegularExpressions;

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
                //var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                //    .Join(_context.floors, z => z.Floor.FloorId, f => f.FloorId, (z, f) => new { f, z })
                //    .Join(_context.buildings, bz => bz.z.BuildingId, bu => bu.BuildingId, (bu, bz) => new
                //    {
                //        buildingName = bz.BuildingName,
                //        electricityBill = bu.z.ElectricMeter,
                //        waterBill = bu.z.WaterMeter
                //    });
                var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                    .Join(_context.buildings, b => b.BuildingId, z => z.BuildingId, (b, z) => new { b.ElectricMeter, b.WaterMeter, b.BuildingId, b.Building.BuildingName})
                    .GroupBy(b => b.BuildingName)
                    .Select(x => new { ElectricMeter = x.Select(g => g.ElectricMeter).Sum(), WaterMeter = x.Select(f => f.WaterMeter).Sum(), BuildingName = x.Key });
                //var robotLocations = context.RobotFactories
                //      .Join(
                //          context.RobotDogs,
                //          f => f.RobotFactoryId,
                //          d => d.RobotFactoryId,
                //          (f, d) => new { f.Location, d.Guns })
                //      .GroupBy(f => f.Location)
                //      .Select(x => new { Location = x.Key, Guns = x.Select(g => g.Guns).Sum() });

                return result;
            }

            else
            {
                var result = _context.zones.Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                    .Join(_context.Facilities, f => f.FacilityId, z => z.FacilityId, (f,z ) => new { f.ElectricMeter, f.WaterMeter, f.Facility.FacilityName})
                    .GroupBy(f => f.FacilityName)
                    .Select(x => new { ElectricMeter = x.Select(g => g.ElectricMeter).Sum(), WaterMeter = x.Select(h => h.WaterMeter).Sum(), FacilityName = x.Key });
                return result;
            }
        }
    }

}

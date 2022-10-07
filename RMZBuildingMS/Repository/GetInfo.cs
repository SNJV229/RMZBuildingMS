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

        public IQueryable getAtLevel(string facility, DateTime startDate, DateTime endDate, string levelOfInformation)
        { 
            if (levelOfInformation == "Zone")
            {
                var result = _context.zones.Where(x => ).Join(_context.floors, z=>z.Floor.FloorId, f=>f.FloorId, (z,f) =>  )
                return result;
            }
            else {
                var result = _context.zones;
                return result; }
        }
    }

}

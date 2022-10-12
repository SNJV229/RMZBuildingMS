namespace RMZBuildingMS.Repository
{
    public interface IGetInfo
    {
        //public IQueryable getAtZone(string facility, string dateRange);
        //public IQueryable getAtBuilding(string facility, string dateRange);
        //public IQueryable getAtFacility(string facility, string dateRange);    

        public IQueryable getAtLevel(string levelOfInformation, DateTime startDate, DateTime endDate);
    }
}

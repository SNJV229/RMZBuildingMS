using RMZBuildingMS.Controllers;
using RMZBuildingMS.Repository;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using RMZBuildingMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace RMZBuildingTest
{
    public class RMZTest
    {
        private readonly IGetInfo _iGetInfo;
        private readonly RMZController _rmzController;
        private readonly RMZContext _context;


        public RMZTest()
        {
            _iGetInfo = A.Fake<IGetInfo>();
            _rmzController = new RMZController(_context, _iGetInfo);
        }

        [Fact]
        public void rmzcontroller_getAtLevel_Zone_Returnok()
        {
            string facilitylevel = "Zone";
            DateTime startDate = new DateTime(2022,06,10);
            DateTime EndDate = new DateTime(2022, 08, 13);
            var obj = new
            {
                facilityName = "WhiteField",
                buildingName = "Building2",
                floorName = "Floor2",
                zoneName = "Zone6",
                zoneElectricreading = 3549.0,
                zoneWaterreading = 268.0
            };

            A.CallTo(() => _iGetInfo.getAtLevel(A<string>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored));

            var result = _rmzController.GetActionResult(facilitylevel, startDate, EndDate);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void rmzcontroller_getAtLevel_Building_Returnok()
        {
            string facilitylevel = "Building";
            DateTime startDate = new DateTime(2022, 06, 10);
            DateTime EndDate = new DateTime(2022, 08, 13);
            var obj = new
            {
                buildingName = "Building2",
                zoneElectricreading = 3549.0,
                zoneWaterreading = 268.0
            };

            A.CallTo(() => _iGetInfo.getAtLevel(A<string>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored));

            var result = _rmzController.GetActionResult(facilitylevel, startDate, EndDate);

            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void rmzcontroller_getAtLevel_Facility_Returnok()
        {
            string facilitylevel = "Facility";
            DateTime startDate = new DateTime(2022, 06, 10);
            DateTime EndDate = new DateTime(2022, 08, 13);
            var obj = new
            {
                FacilityName = "Electronicity",
                zoneElectricreading = 2098.0,
                zoneWaterreading = 98.0
            };

            A.CallTo(() => _iGetInfo.getAtLevel(A<string>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored));

            var result = _rmzController.GetActionResult(facilitylevel, startDate, EndDate);

            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}



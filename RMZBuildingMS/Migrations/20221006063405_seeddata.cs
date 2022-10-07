using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMZBuildingMS.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "Bangalore" },
                    { 2, "Gurgao" },
                    { 3, "Delhi" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityId", "CityId", "FacilityName" },
                values: new object[,]
                {
                    { 1, 1, "WhiteField" },
                    { 2, 2, "sector 5" },
                    { 3, 3, "hauz kahs" },
                    { 4, 1, "Electronic city" }
                });

            migrationBuilder.InsertData(
                table: "buildings",
                columns: new[] { "BuildingId", "BuildingName", "FacilityId" },
                values: new object[,]
                {
                    { 1, "Building1", 1 },
                    { 2, "Building2", 2 },
                    { 3, "Building3", 3 },
                    { 4, "building4", 4 }
                });

            migrationBuilder.InsertData(
                table: "floors",
                columns: new[] { "FloorId", "BuildingId", "FloorName" },
                values: new object[,]
                {
                    { 1, 1, "Floor1" },
                    { 2, 2, "Floor2" },
                    { 3, 3, "Floor3" },
                    { 4, 4, "Floor4" }
                });

            migrationBuilder.InsertData(
                table: "zones",
                columns: new[] { "ZoneId", "BuildingId", "ElectricMeter", "FacilityId", "FloorId", "ReadingDate", "WaterMeter" },
                values: new object[,]
                {
                    { "Zone1", 1, 3004m, 2, 1, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 298m },
                    { "Zone2", 2, 2509m, 3, 2, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 208m },
                    { "Zone3", 3, 2507m, 1, 3, new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 298m },
                    { "Zone4", 4, 2098m, 4, 4, new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 98m },
                    { "Zone5", 3, 2004m, 2, 1, new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 203m },
                    { "Zone6", 2, 3549m, 1, 2, new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 268m },
                    { "Zone7", 2, 2508m, 3, 3, new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 283m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone1");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone2");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone3");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone4");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone5");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone6");

            migrationBuilder.DeleteData(
                table: "zones",
                keyColumn: "ZoneId",
                keyValue: "Zone7");

            migrationBuilder.DeleteData(
                table: "floors",
                keyColumn: "FloorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "floors",
                keyColumn: "FloorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "floors",
                keyColumn: "FloorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "floors",
                keyColumn: "FloorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "buildings",
                keyColumn: "BuildingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "buildings",
                keyColumn: "BuildingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "buildings",
                keyColumn: "BuildingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "buildings",
                keyColumn: "BuildingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "CityId",
                keyValue: 3);
        }
    }
}

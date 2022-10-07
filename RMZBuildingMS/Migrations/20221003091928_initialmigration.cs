using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RMZBuildingMS.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityName = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingName = table.Column<string>(type: "text", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_buildings_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FloorName = table.Column<string>(type: "text", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floors", x => x.FloorId);
                    table.ForeignKey(
                        name: "FK_floors_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    ZoneId = table.Column<string>(type: "text", nullable: false),
                    ElectricMeter = table.Column<decimal>(type: "numeric", nullable: false),
                    WaterMeter = table.Column<decimal>(type: "numeric", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_zones_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zones_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zones_floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "floors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buildings_FacilityId",
                table: "buildings",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CityId",
                table: "Facilities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_floors_BuildingId",
                table: "floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_zones_BuildingId",
                table: "zones",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_zones_FacilityId",
                table: "zones",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_zones_FloorId",
                table: "zones",
                column: "FloorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zones");

            migrationBuilder.DropTable(
                name: "floors");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}

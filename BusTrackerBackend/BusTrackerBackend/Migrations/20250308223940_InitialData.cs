using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusRoutes",
                columns: new[] { "RouteId", "BusId", "EndPoint", "Name", "StartPoint" },
                values: new object[] { new Guid("f4e3d2c1-b6a5-789a-9012-3456789abcd1"), null, "Central Park", "Downtown Express", "Downtown Station" });

            migrationBuilder.InsertData(
                table: "BusStops",
                columns: new[] { "BusStopId", "BusRouteId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { new Guid("a1a9b2c3-d4e5-678f-9012-3456789abcde"), null, 40.712775999999998, -74.005973999999995, "Downtown Station" },
                    { new Guid("b2b9c2d3-e4f5-678a-9012-3456789abcdf"), null, 40.785091000000001, -73.968284999999995, "Central Park" }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "Capacity", "IsActive", "Model", "PlateNumber" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 40, false, "Hyundai", "FB123" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 50, true, "Toyota", "FB23CA" }
                });

            migrationBuilder.InsertData(
                table: "BusLocations",
                columns: new[] { "LocationId", "BusId", "Latitude", "Longitude", "Timestamp" },
                values: new object[] { new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 40.730609999999999, -73.935242000000002, new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "ScheduleId", "ArrivalTime", "BusId", "DepartureTime", "RouteId" },
                values: new object[] { new Guid("e7d6c5b4-a3b2-567a-9012-3456789abcd2"), new DateTime(2024, 10, 27, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2024, 10, 27, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("f4e3d2c1-b6a5-789a-9012-3456789abcd1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusLocations",
                keyColumn: "LocationId",
                keyValue: new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "ScheduleId",
                keyValue: new Guid("e7d6c5b4-a3b2-567a-9012-3456789abcd2"));

            migrationBuilder.DeleteData(
                table: "BusStops",
                keyColumn: "BusStopId",
                keyValue: new Guid("a1a9b2c3-d4e5-678f-9012-3456789abcde"));

            migrationBuilder.DeleteData(
                table: "BusStops",
                keyColumn: "BusStopId",
                keyValue: new Guid("b2b9c2d3-e4f5-678a-9012-3456789abcdf"));

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "BusRoutes",
                keyColumn: "RouteId",
                keyValue: new Guid("f4e3d2c1-b6a5-789a-9012-3456789abcd1"));

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}

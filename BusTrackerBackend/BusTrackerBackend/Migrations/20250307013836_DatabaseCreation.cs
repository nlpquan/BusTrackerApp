using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CurrentLatitude = table.Column<double>(type: "float", nullable: false),
                    CurrentLongitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "BusStops",
                columns: table => new
                {
                    BusStopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.BusStopId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StartPoint = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EndPoint = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BusesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Buses_BusesId",
                        column: x => x.BusesId,
                        principalTable: "Buses",
                        principalColumn: "BusId");
                });

            migrationBuilder.CreateTable(
                name: "TrackingHistories",
                columns: table => new
                {
                    TrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingHistories", x => x.TrackingId);
                    table.ForeignKey(
                        name: "FK_TrackingHistories_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteStops",
                columns: table => new
                {
                    RouteStopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusStopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusStopOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStops", x => x.RouteStopId);
                    table.ForeignKey(
                        name: "FK_RouteStops_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "BusStopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStops_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BusesId",
                table: "Routes",
                column: "BusesId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_BusStopId",
                table: "RouteStops",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_RouteId",
                table: "RouteStops",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingHistories_BusId",
                table: "TrackingHistories",
                column: "BusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteStops");

            migrationBuilder.DropTable(
                name: "TrackingHistories");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Buses");
        }
    }
}

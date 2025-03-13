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
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_CustomerId",
                table: "CustomerBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTicket_AspNetUsers_AdminId",
                table: "DriverTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTicket_AspNetUsers_DriverId",
                table: "DriverTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTicket_AspNetUsers_UserId",
                table: "DriverTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTicket_Bus_BusId",
                table: "DriverTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTicket_CustomerBooking_CustomerBookingId",
                table: "DriverTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverTicket",
                table: "DriverTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerBooking",
                table: "CustomerBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bus",
                table: "Bus");

            migrationBuilder.RenameTable(
                name: "DriverTicket",
                newName: "DriverTickets");

            migrationBuilder.RenameTable(
                name: "CustomerBooking",
                newName: "CustomerBookings");

            migrationBuilder.RenameTable(
                name: "Bus",
                newName: "Buses");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTicket_UserId",
                table: "DriverTickets",
                newName: "IX_DriverTickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTicket_DriverId",
                table: "DriverTickets",
                newName: "IX_DriverTickets_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTicket_CustomerBookingId",
                table: "DriverTickets",
                newName: "IX_DriverTickets_CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTicket_BusId",
                table: "DriverTickets",
                newName: "IX_DriverTickets_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTicket_AdminId",
                table: "DriverTickets",
                newName: "IX_DriverTickets_AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerBooking_CustomerId",
                table: "CustomerBookings",
                newName: "IX_CustomerBookings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverTickets",
                table: "DriverTickets",
                column: "DriverTicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerBookings",
                table: "CustomerBookings",
                column: "CustomerBookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buses",
                table: "Buses",
                column: "BusId");

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "Capacity", "IsActive", "Model", "PlateNumber" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 40, false, "Hyundai", "FB123" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 50, true, "Toyota", "FB23CA" }
                });

            migrationBuilder.InsertData(
                table: "CustomerBookings",
                columns: new[] { "CustomerBookingId", "BookingDate", "Capacity", "CustomerId", "CustomerMessage", "Destination", "Status" },
                values: new object[] { new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"), new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Utc), 4, new Guid("e356d627-3948-4ec4-eca6-08dd61c93b20"), "Your trip to New York City is booked!", "New York City", "Pending" });

            migrationBuilder.InsertData(
                table: "DriverTickets",
                columns: new[] { "DriverTicketId", "AdminId", "ArrivalTime", "BusId", "BusRoute", "CompletedAt", "CustomerBookingId", "DepartureTime", "DriverId", "Status", "UserId" },
                values: new object[] { new Guid("f9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("e64a6970-9d9a-4182-eca7-08dd61c93b20"), new DateTime(2024, 10, 27, 18, 0, 0, 0, DateTimeKind.Utc), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Route 101", null, new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"), new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("f3b45a44-0a92-4534-eca8-08dd61c93b20"), "Pending", null });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_AspNetUsers_CustomerId",
                table: "CustomerBookings",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTickets_AspNetUsers_AdminId",
                table: "DriverTickets",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTickets_AspNetUsers_DriverId",
                table: "DriverTickets",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTickets_AspNetUsers_UserId",
                table: "DriverTickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTickets_Buses_BusId",
                table: "DriverTickets",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTickets_CustomerBookings_CustomerBookingId",
                table: "DriverTickets",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_AspNetUsers_CustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTickets_AspNetUsers_AdminId",
                table: "DriverTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTickets_AspNetUsers_DriverId",
                table: "DriverTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTickets_AspNetUsers_UserId",
                table: "DriverTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTickets_Buses_BusId",
                table: "DriverTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverTickets_CustomerBookings_CustomerBookingId",
                table: "DriverTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverTickets",
                table: "DriverTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerBookings",
                table: "CustomerBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buses",
                table: "Buses");

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "DriverTickets",
                keyColumn: "DriverTicketId",
                keyValue: new Guid("f9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "CustomerBookings",
                keyColumn: "CustomerBookingId",
                keyValue: new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"));

            migrationBuilder.RenameTable(
                name: "DriverTickets",
                newName: "DriverTicket");

            migrationBuilder.RenameTable(
                name: "CustomerBookings",
                newName: "CustomerBooking");

            migrationBuilder.RenameTable(
                name: "Buses",
                newName: "Bus");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTickets_UserId",
                table: "DriverTicket",
                newName: "IX_DriverTicket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTickets_DriverId",
                table: "DriverTicket",
                newName: "IX_DriverTicket_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTickets_CustomerBookingId",
                table: "DriverTicket",
                newName: "IX_DriverTicket_CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTickets_BusId",
                table: "DriverTicket",
                newName: "IX_DriverTicket_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverTickets_AdminId",
                table: "DriverTicket",
                newName: "IX_DriverTicket_AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerBookings_CustomerId",
                table: "CustomerBooking",
                newName: "IX_CustomerBooking_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverTicket",
                table: "DriverTicket",
                column: "DriverTicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerBooking",
                table: "CustomerBooking",
                column: "CustomerBookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bus",
                table: "Bus",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooking_AspNetUsers_CustomerId",
                table: "CustomerBooking",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTicket_AspNetUsers_AdminId",
                table: "DriverTicket",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTicket_AspNetUsers_DriverId",
                table: "DriverTicket",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTicket_AspNetUsers_UserId",
                table: "DriverTicket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTicket_Bus_BusId",
                table: "DriverTicket",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverTicket_CustomerBooking_CustomerBookingId",
                table: "DriverTicket",
                column: "CustomerBookingId",
                principalTable: "CustomerBooking",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

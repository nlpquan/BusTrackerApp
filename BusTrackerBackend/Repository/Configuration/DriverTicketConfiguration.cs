using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class DriverTicketConfiguration : IEntityTypeConfiguration<DriverTicket>
    {
        public void Configure(EntityTypeBuilder<DriverTicket> builder)
        {
            builder.HasData
            (
                new DriverTicket
                {
                    Id = new Guid("f9d4c053-49b6-410c-bc78-2d54a9991870"), // Example Guid for DriverTicket
                    CustomerBookingId = new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"), // Example CustomerBookingId (ForeignKey to CustomerBooking)
                    AdminId = new Guid("E64A6970-9D9A-4182-ECA7-08DD61C93B20"), // Example AdminId (ForeignKey to Admin)
                    DriverId = new Guid("F3B45A44-0A92-4534-ECA8-08DD61C93B20"), // Example DriverId (ForeignKey to Driver)
                    BusId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), // Example BusId (ForeignKey to Bus)
                    BusRoute = "Route 101", // Example bus route
                    DepartureTime = new DateTime(2024, 10, 27, 10, 0, 0, DateTimeKind.Utc), // Example departure time
                    ArrivalTime = new DateTime(2024, 10, 27, 18, 0, 0, DateTimeKind.Utc), // Example arrival time
                    Status = "Pending", // Initial status of the ticket
                    CompletedAt = null // Not completed yet
                }
            );
        }
    }


}

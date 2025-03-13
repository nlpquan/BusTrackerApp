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
    public class CustomerBookingConfiguration : IEntityTypeConfiguration<CustomerBooking>
    {
        public void Configure(EntityTypeBuilder<CustomerBooking> builder)
        {
            builder.HasData
            (
                new CustomerBooking
                {
                    Id = new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"),  // Guid for the CustomerBooking
                    CustomerId = new Guid("E356D627-3948-4EC4-ECA6-08DD61C93B20"),  // Example CustomerId (foreign key to User)
                    Capacity = 4,  // Example capacity
                    Destination = "New York City",  // Example destination
                    BookingDate = new DateTime(2024, 10, 27, 10, 0, 0, DateTimeKind.Utc),  // Example booking date
                    Status = "Pending",  // Initial status
                    CustomerMessage = "Your trip to New York City is booked!"  // Customer message
                }
            );
        }
    }

}

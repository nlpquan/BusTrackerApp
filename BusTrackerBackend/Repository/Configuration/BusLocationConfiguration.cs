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
    public class BusLocationConfiguration : IEntityTypeConfiguration<BusLocation>
    {
        public void Configure(EntityTypeBuilder<BusLocation> builder)
        {
            builder.HasData
            (
                new BusLocation
                {
                    Id = new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"),
                    BusId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), // Toyota Bus
                    Latitude = 40.730610,
                    Longitude = -73.935242,
                    Timestamp = new DateTime(2024, 10, 27, 10, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }

}

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
    public class BusScheduleConfiguration : IEntityTypeConfiguration<BusSchedule>
    {
        public void Configure(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.HasData
            (
                new BusSchedule
                {
                    Id = new Guid("e7d6c5b4-a3b2-567a-9012-3456789abcd2"),
                    BusId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), // Toyota Bus
                    RouteId = new Guid("f4e3d2c1-b6a5-789a-9012-3456789abcd1"),
                    DepartureTime = new DateTime(2024, 10, 27, 11, 0, 0, DateTimeKind.Utc),
                    ArrivalTime = new DateTime(2024, 10, 27, 12, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }


}

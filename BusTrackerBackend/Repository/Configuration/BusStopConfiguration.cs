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
    public class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> builder)
        {
            builder.HasData
            (
                new BusStop
                {
                    Id = new Guid("a1a9b2c3-d4e5-678f-9012-3456789abcde"),
                    Name = "Downtown Station",
                    Latitude = 40.712776,
                    Longitude = -74.005974
                },
                new BusStop
                {
                    Id = new Guid("b2b9c2d3-e4f5-678a-9012-3456789abcdf"),
                    Name = "Central Park",
                    Latitude = 40.785091,
                    Longitude = -73.968285
                }
            );
        }
    }


}

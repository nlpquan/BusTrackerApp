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
    public class BusRouteConfiguration : IEntityTypeConfiguration<BusRoute>
    {
        public void Configure(EntityTypeBuilder<BusRoute> builder)
        {
            builder.HasData
            (
                new BusRoute
                {
                    Id = new Guid("f4e3d2c1-b6a5-789a-9012-3456789abcd1"),
                    Name = "Downtown Express",
                    StartPoint = "Downtown Station",
                    EndPoint = "Central Park"
                }
            );
        }
    }


}

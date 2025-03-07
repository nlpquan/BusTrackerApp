using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities.Models;

namespace Repository.Configuration
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasData
            (
            new Bus
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                PlateNumber = "FB23CA",
                Model = "Toyota",
                Capacity = 50,
                CurrentLatitude = 29.32959,
                CurrentLongitude = 147.39414
            },
            new Bus
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                PlateNumber = "FB123",
                Model = "Huyndai",
                Capacity = 40,
                CurrentLatitude = 59.32959,
                CurrentLongitude = 47.39414
            }

            );
        }
    }
}

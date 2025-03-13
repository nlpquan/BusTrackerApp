using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("d8c7b6a5-9e8d-1234-5678-90abcdef1234"),  // Static GUID value
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("f5b28ab8-3031-4d80-9b87-7e4cf91e6d30"),  // Static GUID value
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("b8c8a678-e44f-42f2-bfbf-5fa9e6745b26"),  // Static GUID value
                    Name = "Driver",
                    NormalizedName = "DRIVER"
                }
            );
        }
    }
}

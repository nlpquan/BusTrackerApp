using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BusDto
    {
        public Guid Id { get; init; }
        public string? PlateNumberAndModel { get; init; }
        public int Capacity { get; init; }
        public bool IsActive { get; init; }
    }

}

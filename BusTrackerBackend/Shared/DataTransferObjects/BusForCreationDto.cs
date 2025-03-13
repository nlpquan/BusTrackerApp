using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BusForCreationDto(Guid Id, string PlateNumber, string Model, int Capacity, bool isActive);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DriverTicketForUpdateDto(Guid Id, string BusRoute, DateTime DepartureTime, DateTime ArrivalTime,
        string Status, DateTime CompletedAt);
}

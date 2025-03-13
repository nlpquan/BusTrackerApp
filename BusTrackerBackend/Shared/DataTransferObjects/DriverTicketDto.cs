using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DriverTicketDto
    {
        public Guid Id { get; init; }
        public string? BusRoute { get; init; }
        public DateTime DepartureTime { get; init; }
        public DateTime ArrivalTime { get; init; }
        public string? Status { get; init; }
        public DateTime CompletedAt { get; init; }
    }
}

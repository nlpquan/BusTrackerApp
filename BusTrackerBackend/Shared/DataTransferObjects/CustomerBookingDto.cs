using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CustomerBookingDto
    {
        public Guid Id { get; init; }
        public int Capacity { get; init; }
        public string? Destination { get; init; }
        public DateTime BookingDate { get; init; }
        public string? Status { get; init; }
        public string? CustomerMessage { get; init; }
    }
}

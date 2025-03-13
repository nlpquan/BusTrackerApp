using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CustomerBookingForUpdateDto(Guid Id, int Capacity, string Destination, DateTime BookingDate, string Status,
        string CustomerMessage);
}

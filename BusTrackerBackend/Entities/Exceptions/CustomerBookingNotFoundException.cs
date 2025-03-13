using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CustomerBookingNotFoundException : NotFoundException
    {
        public CustomerBookingNotFoundException(Guid customerBookingId)
        : base($"The customer booking with id: {customerBookingId} doesn't exist in the database.")
        {
        }
    }
}

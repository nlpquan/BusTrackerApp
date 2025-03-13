using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DriverTicketNotFoundException : NotFoundException
    {
        public DriverTicketNotFoundException(Guid driverTicketId)
        : base($"The driver ticket with id: {driverTicketId} doesn't exist in the database.")
        {
        }
    }
}

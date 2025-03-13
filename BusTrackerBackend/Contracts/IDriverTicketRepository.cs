using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDriverTicketRepository
    {
        IEnumerable<DriverTicket> GetAllDriverTickets(bool trackChanges);
        DriverTicket GetDriverTicket(Guid driverTicketId, bool trackChanges);
        void CreateDriverTicket(DriverTicket driverTicket);
        void DeleteDriverTicket(DriverTicket driverTicket);
    }
}

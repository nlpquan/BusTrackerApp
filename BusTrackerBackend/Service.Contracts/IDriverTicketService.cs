using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDriverTicketService
    {
        IEnumerable<DriverTicketDto> GetAllDriverTickets(bool trackChanges);
        DriverTicketDto GetDriverTicket(Guid DriverTicketId, bool trackChanges);
        DriverTicketDto CreateDriverTicket(DriverTicketForCreationDto driverTicket);
        void DeleteDriverTicket(Guid driverTicketId, bool trackChanges);
        void UpdateDriverTicket(Guid driverTicketId, DriverTicketForUpdateDto driverTicketForUpdate, bool trackChanges);

    }
}

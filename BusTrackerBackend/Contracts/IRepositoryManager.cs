using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IBusRepository Bus { get; }
        ICustomerBookingRepository CustomerBooking { get; }
        IDriverTicketRepository DriverTicket { get; }
        void Save();
    }

}

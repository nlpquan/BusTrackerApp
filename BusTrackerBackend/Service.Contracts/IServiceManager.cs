using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IBusService BusService { get; }
        ICustomerBookingService CustomerBookingService { get; }
        IDriverTicketService DriverTicketService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}

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
        IBusLocationService BusLocationService { get; }
        IBusRouteService BusRouteService { get; }
        IBusScheduleService BusScheduleService { get; }
        IBusStopService BusStopService { get; }
    }
}

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
        IBusLocationRepository BusLocation { get; }
        IBusRouteRepository BusRoute { get; }
        IBusScheduleRepository BusSchedule { get; }
        IBusStopRepository BusStop { get; }
        void Save();
    }

}

using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBusService> _busService;
        private readonly Lazy<IBusLocationService> _busLocationService;
        private readonly Lazy<IBusRouteService> _busRouteService;
        private readonly Lazy<IBusScheduleService> _busScheduleService;
        private readonly Lazy<IBusStopService> _busStopService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger)
        {
            _busService = new Lazy<IBusService>(() => new
            BusService(repositoryManager, logger));

            _busLocationService = new Lazy<IBusLocationService>(() => new
            BusLocationService(repositoryManager, logger));

            _busRouteService = new Lazy<IBusRouteService>(() => new
            BusRouteService(repositoryManager, logger));

            _busScheduleService = new Lazy<IBusScheduleService>(() => new
            BusScheduleService(repositoryManager, logger));

            _busStopService = new Lazy<IBusStopService>(() => new
            BusStopService(repositoryManager, logger));
        }
        public IBusService BusService => _busService.Value;
        public IBusLocationService BusLocationService => _busLocationService.Value;
        public IBusRouteService BusRouteService => _busRouteService.Value;
        public IBusScheduleService BusScheduleService => _busScheduleService.Value;
        public IBusStopService BusStopService => _busStopService.Value;
    }

}

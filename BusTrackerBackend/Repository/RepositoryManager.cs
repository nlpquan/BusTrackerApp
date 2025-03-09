using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBusRepository> _busRepository;
        private readonly Lazy<IBusLocationRepository> _busLocationRepository;
        private readonly Lazy<IBusRouteRepository> _busRouteRepository;
        private readonly Lazy<IBusScheduleRepository> _busScheduleRepository;
        private readonly Lazy<IBusStopRepository> _busStopRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _busRepository = new Lazy<IBusRepository>(() => new
            BusRepository(repositoryContext));

            _busLocationRepository = new Lazy<IBusLocationRepository>(() => new
            BusLocationRepository(repositoryContext));

            _busRouteRepository = new Lazy<IBusRouteRepository>(() => new
            BusRouteRepository(repositoryContext));

            _busScheduleRepository = new Lazy<IBusScheduleRepository>(() => new
            BusScheduleRepository(repositoryContext));

            _busStopRepository = new Lazy<IBusStopRepository>(() => new
            BusStopRepository(repositoryContext));
        }
        public IBusRepository Bus => _busRepository.Value;
        public IBusLocationRepository BusLocation => _busLocationRepository.Value;
        public IBusRouteRepository BusRoute => _busRouteRepository.Value;
        public IBusScheduleRepository BusSchedule => _busScheduleRepository.Value;
        public IBusStopRepository BusStop => _busStopRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}

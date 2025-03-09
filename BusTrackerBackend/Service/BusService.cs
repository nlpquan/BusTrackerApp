using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class BusService : IBusService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public BusService(IRepositoryManager repository, ILoggerManager
        logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }

}

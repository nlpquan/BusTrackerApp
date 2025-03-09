using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BusLocationService : IBusLocationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public BusLocationService(IRepositoryManager repository, ILoggerManager
        logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}

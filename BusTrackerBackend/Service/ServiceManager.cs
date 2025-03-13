using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<ICustomerBookingService> _customerBookingService;
        private readonly Lazy<IDriverTicketService> _driverTicketService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _busService = new Lazy<IBusService>(() => new
            BusService(repositoryManager, logger, mapper));

            _customerBookingService = new Lazy<ICustomerBookingService>(() => new
            CustomerBookingService(repositoryManager, logger, mapper));

            _driverTicketService = new Lazy<IDriverTicketService>(() => new
            DriverTicketService(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() => new 
            AuthenticationService(logger, mapper, userManager, configuration));
        }
        public IBusService BusService => _busService.Value;
        public ICustomerBookingService CustomerBookingService => _customerBookingService.Value;
        public IDriverTicketService DriverTicketService => _driverTicketService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }

}

using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly Lazy<IBusRepository> _busRepository;
        private readonly Lazy<ICustomerBookingRepository> _customerBookingRepository;
        private readonly Lazy<IDriverTicketRepository> _driverTicketRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly ILoggerManager _logger;  // Add the logger here

        public RepositoryManager(RepositoryContext repositoryContext, UserManager<User> userManager, ILoggerManager logger)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));  // Ensure logger is passed and not null

            _busRepository = new Lazy<IBusRepository>(() => new BusRepository(repositoryContext));

            // Update to inject ILoggerManager into CustomerBookingRepository
            _customerBookingRepository = new Lazy<ICustomerBookingRepository>(() => new CustomerBookingRepository(repositoryContext, _logger));

            _driverTicketRepository = new Lazy<IDriverTicketRepository>(() => new DriverTicketRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_userManager));
        }

        public IBusRepository Bus => _busRepository.Value;
        public ICustomerBookingRepository CustomerBooking => _customerBookingRepository.Value;
        public IDriverTicketRepository DriverTicket => _driverTicketRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }

}

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
        private readonly Lazy<ICustomerBookingRepository> _customerBookingRepository;
        private readonly Lazy<IDriverTicketRepository> _driverTicketRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _busRepository = new Lazy<IBusRepository>(() => new
            BusRepository(repositoryContext));

            _customerBookingRepository = new Lazy<ICustomerBookingRepository>(() => new
            CustomerBookingRepository(repositoryContext));

            _driverTicketRepository = new Lazy<IDriverTicketRepository>(() => new
            DriverTicketRepository(repositoryContext));
        }
        public IBusRepository Bus => _busRepository.Value;
        public ICustomerBookingRepository CustomerBooking => _customerBookingRepository.Value;
        public IDriverTicketRepository DriverTicket => _driverTicketRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}

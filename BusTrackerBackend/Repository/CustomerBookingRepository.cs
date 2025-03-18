using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerBookingRepository : RepositoryBase<CustomerBooking>, ICustomerBookingRepository
    {
        private readonly ILoggerManager _logger;
        public CustomerBookingRepository(RepositoryContext repositoryContext, ILoggerManager logger)
        : base(repositoryContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Ensure logger is not null
        }

        public IEnumerable<CustomerBooking> GetAllCustomerBookings(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(c => c.Destination).ToList();

        public CustomerBooking GetCustomerBooking(Guid customerBookingId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(customerBookingId), trackChanges).SingleOrDefault();

        public IEnumerable<CustomerBooking> GetCustomerBookingsForCustomer(Guid customerId, bool trackChanges)
        {
            // Ensure customerId is not null or invalid
            if (customerId == Guid.Empty)
            {
                return Enumerable.Empty<CustomerBooking>(); // Return an empty collection if invalid
            }

            // Explicitly ensure that only valid CustomerId is considered and NULL values are excluded
            var customerBookingsFromDb = FindByCondition(e => e.CustomerId == customerId && e.CustomerId != null, trackChanges)
                .OrderBy(e => e.Destination)
                .ToList();

            return customerBookingsFromDb;
        }

        public CustomerBooking GetCustomerBookingForCustomer(Guid customerId, Guid id, bool trackChanges)
        {
            return FindByCondition(e => e.CustomerId.Equals(customerId) && e.Id.Equals(id), trackChanges)
                         .SingleOrDefault(); // Use synchronous method
        }


        public void CreateCustomerBooking(CustomerBooking customerBooking) => Create(customerBooking);
        public void DeleteCustomerBooking(CustomerBooking customerBooking) => Delete(customerBooking);
    }
}

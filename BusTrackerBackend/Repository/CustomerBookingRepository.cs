using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerBookingRepository : RepositoryBase<CustomerBooking>, ICustomerBookingRepository
    {
        public CustomerBookingRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<CustomerBooking> GetAllCustomerBookings(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(c => c.Destination).ToList();

        public CustomerBooking GetCustomerBooking(Guid customerBookingId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(customerBookingId), trackChanges).SingleOrDefault();

        public void CreateCustomerBooking(CustomerBooking customerBooking) => Create(customerBooking);
        public void DeleteCustomerBooking(CustomerBooking customerBooking) => Delete(customerBooking);
    }
}

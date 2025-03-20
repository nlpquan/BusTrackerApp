using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerBookingRepository
    {
        IEnumerable<CustomerBooking> GetAllCustomerBookings(bool trackChanges);
        CustomerBooking GetCustomerBooking(Guid customerBookingId, bool trackChanges);
        IEnumerable<CustomerBooking> GetCustomerBookingsForCustomer(Guid customerId, bool trackChanges);
        CustomerBooking GetCustomerBookingForCustomer(Guid customerId, Guid id, bool trackChanges); 
        void CreateCustomerBooking(CustomerBooking customerBooking);
        void CreateCustomerBookingForCustomer(Guid customerId, CustomerBooking booking);
        void DeleteCustomerBooking(CustomerBooking customerBooking);
    }
}

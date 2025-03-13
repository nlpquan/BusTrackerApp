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
        void CreateCustomerBooking(CustomerBooking customerBooking);
        void DeleteCustomerBooking(CustomerBooking customerBooking);
    }
}

using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICustomerBookingService
    {
        IEnumerable<CustomerBookingDto> GetAllCustomerBookings(bool trackChanges);
        CustomerBookingDto GetCustomerBooking(Guid customerBookingId, bool trackChanges);
        CustomerBookingDto CreateCustomerBooking(CustomerBookingForCreationDto customerBooking);
        void DeleteCustomerBooking(Guid customerBookingId, bool trackChanges);
        void UpdateCustomerBooking(Guid customerBookingId, CustomerBookingForUpdateDto customerBookingForUpdate, bool trackChanges);

    }
}

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
        IEnumerable<CustomerBookingDto> GetCustomerBookingsForCustomer(Guid customerId, bool trackChanges);
        CustomerBookingDto GetCustomerBookingForCustomer(Guid customerId, Guid bookingId, bool trackChanges);
        CustomerBookingDto CreateCustomerBooking(CustomerBookingForCreationDto customerBooking);
        CustomerBookingDto CreateCustomerBookingForCustomer(Guid customerId, CustomerBookingForCreationDto
customerBookingForCreation, bool trackChanges);
        void DeleteCustomerBooking(Guid customerBookingId, bool trackChanges);
        void UpdateCustomerBooking(Guid customerBookingId, CustomerBookingForUpdateDto customerBookingForUpdate, bool trackChanges);

    }
}

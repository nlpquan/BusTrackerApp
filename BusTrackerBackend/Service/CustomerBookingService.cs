using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CustomerBookingService : ICustomerBookingService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CustomerBookingService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CustomerBookingDto> GetAllCustomerBookings(bool trackChanges)
        {
            var customerBookings = _repository.CustomerBooking.GetAllCustomerBookings(trackChanges);

            var customerBookingsDto = _mapper.Map<IEnumerable<CustomerBookingDto>>(customerBookings);

            return customerBookingsDto;
        }

        public CustomerBookingDto GetCustomerBooking(Guid id, bool trackChanges)
        {
            var customerBooking = _repository.CustomerBooking.GetCustomerBooking(id, trackChanges);
            if (customerBooking is null)
                throw new CustomerBookingNotFoundException(id);

            var customerBookingDto = _mapper.Map<CustomerBookingDto>(customerBooking);
            return customerBookingDto;
        }

        public IEnumerable<CustomerBookingDto> GetCustomerBookingsForCustomer(Guid customerId, bool trackChanges)
        {
            // Ensure the user exists
            var user = _repository.User.GetUserById(customerId, trackChanges);
            if (user is null)
            {
                _logger.LogWarn("User not found for customerId: {CustomerId}", customerId);
                throw new UserNotFoundException(customerId);
            }
            // Get the customer bookings from the repository
            var customerBookingsFromDb = _repository.CustomerBooking.GetCustomerBookingsForCustomer(customerId, trackChanges);

            // Map the result to DTO
            var customerBookingsDto = _mapper.Map<IEnumerable<CustomerBookingDto>>(customerBookingsFromDb);

            return customerBookingsDto;
        }


        public CustomerBookingDto GetCustomerBookingForCustomer(Guid customerId, Guid bookingId, bool trackChanges)
        {
            // Ensure the user exists
            var user = _repository.User.GetUserById(customerId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(customerId);

            // Ensure the booking exists for the customer
            var bookingDb = _repository.CustomerBooking.GetCustomerBookingForCustomer(customerId, bookingId, trackChanges);
            if (bookingDb is null)
                throw new CustomerBookingNotFoundException(bookingId);

            var bookingDto = _mapper.Map<CustomerBookingDto>(bookingDb);
            return bookingDto;
        }



        public CustomerBookingDto CreateCustomerBooking(CustomerBookingForCreationDto customerBooking)
        {
            var customerBookingEntity = _mapper.Map<CustomerBooking>(customerBooking);
            _repository.CustomerBooking.CreateCustomerBooking(customerBookingEntity);
            _repository.Save();
            var customerBookingToReturn = _mapper.Map<CustomerBookingDto>(customerBookingEntity);
            return customerBookingToReturn;
        }

        public CustomerBookingDto CreateCustomerBookingForCustomer(Guid customerId, CustomerBookingForCreationDto
bookingForCreation, bool trackChanges)
        {
            var user = _repository.User.GetUserById(customerId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(customerId);

            var bookingEntity = _mapper.Map<CustomerBooking>(bookingForCreation);
            _repository.CustomerBooking.CreateCustomerBookingForCustomer(customerId, bookingEntity);
            _repository.Save();
            var bookingToReturn = _mapper.Map<CustomerBookingDto>(bookingEntity);
            return bookingToReturn;
        }

        public void DeleteCustomerBooking(Guid customerBookingId, bool trackChanges)
        {
            var customerBooking = _repository.CustomerBooking.GetCustomerBooking(customerBookingId, trackChanges);
            if (customerBooking is null)
                throw new CustomerBookingNotFoundException(customerBookingId);
            _repository.CustomerBooking.DeleteCustomerBooking(customerBooking);
            _repository.Save();
        }

        public void UpdateCustomerBooking(Guid customerBookingId, CustomerBookingForUpdateDto customerBookingForUpdate, bool trackChanges)
        {
            var customerBookingEntity = _repository.CustomerBooking.GetCustomerBooking(customerBookingId, trackChanges);
            if (customerBookingEntity is null)
                throw new CustomerBookingNotFoundException(customerBookingId);
            _mapper.Map(customerBookingForUpdate, customerBookingEntity);
            _repository.Save();
        }
    }
}

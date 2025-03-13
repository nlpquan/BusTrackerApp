using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

        public CustomerBookingDto CreateCustomerBooking(CustomerBookingForCreationDto customerBooking)
        {
            var customerBookingEntity = _mapper.Map<CustomerBooking>(customerBooking);
            _repository.CustomerBooking.CreateCustomerBooking(customerBookingEntity);
            _repository.Save();
            var customerBookingToReturn = _mapper.Map<CustomerBookingDto>(customerBookingEntity);
            return customerBookingToReturn;
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

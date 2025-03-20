using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTrackerBackend.Presentation.Controllers
{
    [Route("api/users/{customerId}/customerbookings")]
    [ApiController]
    public class CustomerBookingsForCustomerController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IUserRepository _userRepository;
        public CustomerBookingsForCustomerController(IServiceManager service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        // Route to get customer bookings for a specific customer (by customerId)
        [HttpGet]
        public IActionResult GetCustomerBookingsForCustomer(Guid customerId)
        {
            // Retrieve user details synchronously from UserRepository
            var user = _userRepository.GetUserById(customerId, trackChanges: false); // Sync method call

            if (user == null)
            {
                return NotFound($"User with ID {customerId} not found.");
            }

            // Fetch customer bookings for the given user
            var customerBookings = _service.CustomerBookingService.GetCustomerBookingsForCustomer(customerId, trackChanges: false);

            return Ok(customerBookings);
        }

        // Route to get a specific booking for a customer (by customerId and bookingId)
        [HttpGet("{id:guid}", Name = "GetCustomerBookingForCustomer")]
        public IActionResult GetCustomerBookingForCustomer(Guid customerId, Guid id)
        {
            var customerBooking = _service.CustomerBookingService.GetCustomerBookingForCustomer(customerId, id, trackChanges: false);
            return Ok(customerBooking);
        }

        // Route to create a new customer booking for a specific customer
        [HttpPost]
        public IActionResult CreateCustomerBookingForCustomer(Guid customerId, [FromBody] CustomerBookingForCreationDto customerBooking)
        {
            if (customerBooking is null)
                return BadRequest("CustomerBookingForCreationDto object is null");
            var bookingToReturn =
            _service.CustomerBookingService.CreateCustomerBookingForCustomer(customerId, customerBooking, trackChanges:
            false);
            return CreatedAtRoute("GetCustomerBookingForCustomer", new {customerId, id =
            bookingToReturn.Id
            },
            bookingToReturn);

        }

        // Route to delete a customer booking for a specific customer
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCustomerBookingForCustomer(Guid customerId, Guid id)
        {
            _service.CustomerBookingService.DeleteCustomerBooking(id, trackChanges: false);
            return NoContent();
        }

        // Route to update a customer booking for a specific customer
        [HttpPut("{id:guid}")]
        public IActionResult UpdateCustomerBookingForCustomer(Guid customerId, Guid id, [FromBody] CustomerBookingForUpdateDto customerBooking)
        {
            if (customerBooking is null)
                return BadRequest("CustomerBookingForUpdateDto object is null");

            _service.CustomerBookingService.UpdateCustomerBooking(id, customerBooking, trackChanges: true);
            return NoContent();
        }
    }
}

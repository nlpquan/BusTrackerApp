using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTrackerBackend.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBookingsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CustomerBookingsController(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetCustomerBookings")]
        public IActionResult GetCustomerBookings()
        {
            var customerBookings = _service.CustomerBookingService.GetAllCustomerBookings(trackChanges: false);
            return Ok(customerBookings);

        }

        [HttpGet("{id:guid}", Name = "CustomerBookingById")]
        public IActionResult GetCustomerBooking(Guid id)
        {
            var customerBooking = _service.CustomerBookingService.GetCustomerBooking(id, trackChanges: false);
            return Ok(customerBooking);
        }

        [HttpPost]
        public IActionResult CreateCustomerBooking([FromBody] CustomerBookingForCreationDto customerBooking)
        {
            if (customerBooking is null)
                return BadRequest("CustomerBookingForCreationDto object is null");
            var createdCustomerBooking = _service.CustomerBookingService.CreateCustomerBooking(customerBooking);
            return CreatedAtRoute("CustomerBookingById", new { id = createdCustomerBooking.Id },
            createdCustomerBooking);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCustomerBooking(Guid id)
        {
            _service.CustomerBookingService.DeleteCustomerBooking(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCustomerBooking(Guid id, [FromBody] CustomerBookingForUpdateDto customerBooking)
        {
            if (customerBooking is null)
                return BadRequest("CustomerBookingForUpdateDto object is null");
            _service.CustomerBookingService.UpdateCustomerBooking(id, customerBooking, trackChanges: true);
            return NoContent();
        }
    }
}

using Entities.Models;
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
    public class DriverTicketsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DriverTicketsController(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetDriverTickets")]
        public IActionResult GetDriverTickets()
        {
            var driverTickets = _service.DriverTicketService.GetAllDriverTickets(trackChanges: false);
            return Ok(driverTickets);

        }

        [HttpGet("{id:guid}", Name = "DriverTicketById")]
        public IActionResult GetDriverTicket(Guid id)
        {
            var driverTicket = _service.DriverTicketService.GetDriverTicket(id, trackChanges: false);
            return Ok(driverTicket);
        }

        [HttpPost]
        public IActionResult CreateDriverTicket([FromBody] DriverTicketForCreationDto driverTicket)
        {
            if (driverTicket is null)
                return BadRequest("DriverTicketForCreationDto object is null");
            var createdDriverTicket = _service.DriverTicketService.CreateDriverTicket(driverTicket);
            return CreatedAtRoute("DriverTicketById", new { id = createdDriverTicket.Id },
            createdDriverTicket);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteDriverTicket(Guid id)
        {
            _service.DriverTicketService.DeleteDriverTicket(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateDriverTicket(Guid id, [FromBody] DriverTicketForUpdateDto driverTicket)
        {
            if (driverTicket is null)
                return BadRequest("DriverTicketForUpdateDto object is null");
            _service.DriverTicketService.UpdateDriverTicket(id, driverTicket, trackChanges: true);
            return NoContent();
        }
    }
}

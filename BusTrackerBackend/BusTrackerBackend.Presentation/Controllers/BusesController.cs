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
    public class BusesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BusesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var buses = _service.BusService.GetAllBuses(trackChanges: false);
            return Ok(buses);

        }

        [HttpGet("{id:guid}", Name = "BusById")]
        public IActionResult GetBus(Guid id)
        {
            var company = _service.BusService.GetBus(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateBus([FromBody] BusForCreationDto bus)
        {
            if (bus is null)
                return BadRequest("BusForCreationDto object is null");
            var createdBus = _service.BusService.CreateBus(bus);
            return CreatedAtRoute("BusById", new { id = createdBus.Id },
            createdBus);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBus(Guid id)
        {
            _service.BusService.DeleteBus(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBus(Guid id, [FromBody] BusForUpdateDto bus)
        {
            if (bus is null)
                return BadRequest("BusForUpdateDto object is null");
            _service.BusService.UpdateBus(id, bus, trackChanges: true);
            return NoContent();
        }
    }

}

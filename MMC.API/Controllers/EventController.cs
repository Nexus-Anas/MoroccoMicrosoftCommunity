using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _service;
    public EventController(IEventService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        try
        {
            var @event = await _service.GetEvent(id);
            return @event is not null ? @event : NotFound();
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db"); }
    }


    [HttpGet]
    public async Task<ActionResult> GetAllEvents()
    {
        try { return Ok(await _service.GetAllEvents()); }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db"); }
    }


    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent([FromBody] Event e)
    {
        try
        {
            if (e == null)
                return BadRequest();

            var @event = await _service.CreateEvent(e);
            return CreatedAtAction(nameof(CreateEvent), new { id = @event.Id }, @event);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new event"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Event>> UpdateEvent(int id, [FromBody] Event e)
    {
        try
        {
            if (id != e.Id)
                return BadRequest("Event ID mismatch");

            var @event = await _service.UpdateEvent(id, e);

            if (@event is null)
                return NotFound($"Event with id {id} not found");

            return Ok(@event);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating event record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        try
        {
            var @event = await _service.GetEvent(id);

            if (@event is null)
                return NotFound($"Event with id {id} not found");

            await _service.DeleteEvent(id);
            return Ok($"Event with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting event record"); }
    }
}
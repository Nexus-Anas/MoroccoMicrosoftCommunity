using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;


namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _service;
    public ParticipantController(IParticipantService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Participant>> Find(int id)
    {
        try
        {
            var participant = await _service.Find(id);
            return participant is not null ? participant : NotFound();
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db"); }
    }


    [HttpGet]
    public async Task<ActionResult> FindAll()
    {
        try { return Ok(await _service.FindAll()); }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db"); }
    }


    [HttpPost]
    public async Task<ActionResult<Participant>> Create([FromBody] Participant p)
    {
        try
        {
            if (p == null)
                return BadRequest();

            var participant = await _service.Create(p);
            return CreatedAtAction(nameof(Create), new { id = participant.Id }, participant);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new participant"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Participant>> Update(int id, [FromBody] Participant p)
    {
        try
        {
            if (id != p.Id)
                return BadRequest("Participant ID mismatch");

            var participant = await _service.Update(id, p);

            if (participant is null)
                return NotFound($"Participant with id {id} not found");

            return Ok(participant);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating participant record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var participant = await _service.Find(id);

            if (participant is null)
                return NotFound($"Participant with id {id} not found");

            await _service.Delete(id);
            return Ok($"Participant with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting participant record"); }
    }
}
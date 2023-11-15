using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeakerController : ControllerBase
{
    private readonly ISpeakerService _service;
    public SpeakerController(ISpeakerService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Speaker>> Find(int id)
    {
        try
        {
            var speaker = await _service.Find(id);
            return speaker is not null ? speaker : NotFound();
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
    public async Task<ActionResult<Speaker>> Create([FromBody] Speaker s)
    {
        try
        {
            if (s == null)
                return BadRequest();

            var speaker = await _service.Create(s);
            return CreatedAtAction(nameof(Create), new { id = speaker.Id }, speaker);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new speaker info"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Speaker>> Update(int id, [FromBody] Speaker s)
    {
        try
        {
            if (id != s.Id)
                return BadRequest("SpeakerInfo ID mismatch");

            var speaker = await _service.Update(id, s);

            if (speaker is null)
                return NotFound($"SpeakerInfo with id {id} not found");

            return Ok(speaker);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating SpeakerInfo record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var speaker = await _service.Find(id);

            if (speaker is null)
                return NotFound($"SpeakerInfo with id {id} not found");

            await _service.Delete(id);
            return Ok($"SpeakerInfo with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting SpeakerInfo record"); }
    }
}
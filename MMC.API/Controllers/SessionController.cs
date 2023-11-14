using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;
    public SessionController(ISessionService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Session>> Find(int id)
    {
        try
        {
            var session = await _service.Find(id);
            return session is not null ? session : NotFound();
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
    public async Task<ActionResult<Session>> Create([FromBody] Session s)
    {
        try
        {
            if (s == null)
                return BadRequest();

            var session = await _service.Create(s);
            return CreatedAtAction(nameof(Create), new { id = session.Id }, session);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new session"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Session>> Update(int id, [FromBody] Session s)
    {
        try
        {
            if (id != s.Id)
                return BadRequest("Session ID mismatch");

            var session = await _service.Update(id, s);

            if (session is null)
                return NotFound($"Session with id {id} not found");

            return Ok(session);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating session record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var city = await _service.Find(id);

            if (city is null)
                return NotFound($"Session with id {id} not found");

            await _service.Delete(id);
            return Ok($"Session with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting session record"); }
    }
}

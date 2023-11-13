using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;


namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SponsorController : ControllerBase
{
    private readonly ISponsorService _service;
    public SponsorController(ISponsorService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Sponsor>> Find(int id)
    {
        try
        {
            var sponsor = await _service.Find(id);
            return sponsor is not null ? sponsor : NotFound();
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
    public async Task<ActionResult<Sponsor>> Create([FromBody] Sponsor s)
    {
        try
        {
            if (s == null)
                return BadRequest();

            var sponsor = await _service.Create(s);
            return CreatedAtAction(nameof(Create), new { id = sponsor.Id }, sponsor);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new sponsor"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Sponsor>> Update(int id, [FromBody] Sponsor s)
    {
        try
        {
            if (id != s.Id)
                return BadRequest("Sponsor ID mismatch");

            var sponsor = await _service.Update(id, s);

            if (sponsor is null)
                return NotFound($"Sponsor with id {id} not found");

            return Ok(sponsor);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating sponsor record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var sponsor = await _service.Find(id);

            if (sponsor is null)
                return NotFound($"Sponsor with id {id} not found");

            await _service.Delete(id);
            return Ok($"Sponsor with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting sponsor record"); }
    }
}

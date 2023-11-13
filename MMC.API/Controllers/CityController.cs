using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _service;
    public CityController(ICityService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<City>> Find(int id)
    {
        try
        {
            var city = await _service.Find(id);
            return city is not null ? city : NotFound();
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
    public async Task<ActionResult<City>> Create([FromBody] City c)
    {
        try
        {
            if (c == null)
                return BadRequest();

            var city = await _service.Create(c);
            return CreatedAtAction(nameof(Create), new { id = city.Id }, city);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new city"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<City>> Update(int id, [FromBody] City c)
    {
        try
        {
            if (id != c.Id)
                return BadRequest("City ID mismatch");

            var city = await _service.Update(id, c);

            if (city is null)
                return NotFound($"City with id {id} not found");

            return Ok(city);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating city record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var city = await _service.Find(id);

            if (city is null)
                return NotFound($"City with id {id} not found");

            await _service.Delete(id);
            return Ok($"City with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting city record"); }
    }
}
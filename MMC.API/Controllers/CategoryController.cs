using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Find(int id)
    {
        try
        {
            var categorie = await _service.Find(id);
            return categorie is not null ? categorie : NotFound();
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
    public async Task<ActionResult<City>> Create([FromBody] Category c)
    {
        try
        {
            if (c == null)
                return BadRequest();

            var categorie = await _service.Create(c);
            return CreatedAtAction(nameof(Create), new { id = categorie.Id }, categorie);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new categorie"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> Update(int id, [FromBody] Category c)
    {
        try
        {
            if (id != c.Id)
                return BadRequest("Categorie ID mismatch");

            var categorie = await _service.Update(id, c);

            if (categorie is null)
                return NotFound($"Categorie with id {id} not found");

            return Ok(categorie);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating categorie record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var categorie = await _service.Find(id);

            if (categorie is null)
                return NotFound($"Categorie with id {id} not found");

            await _service.Delete(id);
            return Ok($"Categorie with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting categorie record"); }
    }
}
using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Services;

namespace MMC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service) => _service = service;




    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Find(int id)
    {
        try
        {
            var user = await _service.Find(id);
            return user is not null ? user : NotFound();
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
    public async Task<ActionResult<User>> Create([FromBody] User u)
    {
        try
        {
            if (u == null)
                return BadRequest();

            var user = await _service.Create(u);
            return CreatedAtAction(nameof(Create), new { id = user.Id }, user);

        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new user"); }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(int id, [FromBody] User u)
    {
        try
        {
            if (id != u.Id)
                return BadRequest("User ID mismatch");

            var user = await _service.Update(id, u);

            if (user is null)
                return NotFound($"User with id {id} not found");

            return Ok(user);
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user record"); }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var user = await _service.Find(id);

            if (user is null)
                return NotFound($"User with id {id} not found");

            await _service.Delete(id);
            return Ok($"User with id {id} deleted");
        }
        catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user record"); }
    }
}

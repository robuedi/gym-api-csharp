using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
        => _workoutService = workoutService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetAll()
        => Ok(await _workoutService.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<Workout>> Get(Guid id)
    {
        var workout = await _workoutService.GetById(id);
        if (workout == null)
        {
            return NotFound();
        }

        return workout;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Workout workout)
    {
        workout.Id = Guid.NewGuid();
        await _workoutService.Create(workout);
        return CreatedAtAction(nameof(Get), new { id = workout.Id }, workout);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Workout workout)
    {
        if (id != workout.Id)
        {
            return BadRequest();
        }

        try
        {
            await _workoutService.Update(workout);
        }
        catch (ArgumentException ex) when (ex.Message.Contains("not found"))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _workoutService.Delete(id);
        return NoContent();
    }
}
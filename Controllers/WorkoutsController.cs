using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
        => _workoutService = workoutService;

    [HttpGet]
    public Task<ActionResult<IEnumerable<Workout>>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<ActionResult<Workout>> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> Create(Workout workout)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> Update(Guid id, Workout workout)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

}
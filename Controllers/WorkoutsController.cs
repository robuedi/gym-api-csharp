using Microsoft.AspNetCore.Mvc;
using web_api.Services;

namespace web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
        => _workoutService = workoutService;

}
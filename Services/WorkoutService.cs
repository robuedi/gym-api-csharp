using web_api.Models;

namespace web_api.Services;

public class WorkoutService
{
    private readonly List<Workout> workouts;

    public WorkoutService()
    {
        workouts = new List<Workout>();
    }
    
}
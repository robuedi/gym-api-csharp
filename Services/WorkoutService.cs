using web_api.Models;

namespace web_api.Services;

public class WorkoutService : IWorkoutInterface
{
    private readonly List<Workout> _workouts;

    public WorkoutService()
    {
        _workouts = new List<Workout>();
    }

    public Task<IEnumerable<Workout>> GetAll()
    {
        return Task.FromResult(_workouts.AsEnumerable());
    }

    public Task<Workout?> GetById(Guid id)
    {
        return Task.FromResult(_workouts.SingleOrDefault(w => w.Id == id));
    }

    public Task Create(Workout workout)
    {
        _workouts.Add(workout);
        return Task.CompletedTask;
    }

    public Task Update(Workout updatedWorkout)
    {
        var oldWorkout = _workouts.SingleOrDefault(w => w.Id == updatedWorkout.Id);
        if (oldWorkout == null)
        {
            throw new ArgumentException("Workout not found.");
        }

        _workouts.Remove(oldWorkout);
        _workouts.Add(updatedWorkout);
        return Task.CompletedTask;
    }

    public Task Delete(Guid id)
    {
        var existingWorkout = _workouts.SingleOrDefault(w => w.Id == id);
        if (existingWorkout != null)
        {
            _workouts.Remove(existingWorkout);
        }

        return Task.CompletedTask;
    }
}
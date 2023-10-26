using web_api.Models;

namespace web_api.Services;

public class WorkoutService : IWorkoutService
{
    private readonly List<Workout> _workouts;

    public WorkoutService()
    {
        _workouts = new List<Workout>
        {
            new Workout
            {
                Id = Guid.NewGuid(),
                Name = "Week Plan",
                Description = "Gym exercise plan.",
                Exercises = new()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Push ups",
                        Sets = 5,
                        Repetitions = 10,
                        Duration = 20
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dumbbell",
                        Sets = 3,
                        Repetitions = 20,
                        Duration = 20
                    },
                }
            }
        };
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
using web_api.Models;

namespace web_api.Services;

public interface IWorkoutService
{
    public Task<IEnumerable<Workout>> GetAll();

    public Task<Workout?> GetById(Guid id);

    public Task Create(Workout workout);

    public Task Update(Workout updatedWorkout);

    public Task Delete(Guid id);
}
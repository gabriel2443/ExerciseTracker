using ExerciseTracker.Data;
using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Services;

public class ExerciseService : IExerciseService
{
    private readonly DataContext _context;

    public ExerciseService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Exercise>> GetAllExercises()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<Exercise> GetExerciseById(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task CreateExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExercise(int id, Exercise exerciseToUpdate)
    {
        var exerciseDb = await _context.Exercises.FindAsync(id);

        exerciseDb.ExerciseName = exerciseToUpdate.ExerciseName;
        exerciseDb.StartTime = exerciseToUpdate.StartTime;
        exerciseDb.EndTime = exerciseToUpdate.EndTime;
        exerciseDb.Duration = exerciseToUpdate.Duration;
        exerciseDb.Comments = exerciseToUpdate.Comments;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExercise(int id)
    {
        var exerciseId = await _context.Exercises.FindAsync(id);

        _context.Exercises.Remove(exerciseId);
        await _context.SaveChangesAsync();
    }
}
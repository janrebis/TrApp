using Microsoft.EntityFrameworkCore;
using TrApp.Identity;
using TrApp.Models;
using TrApp.RepositoryContracts;

namespace TrApp.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExerciseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Exercise> AddExerciseAsync(Exercise exercise)
        {
            await _dbContext.Exercises.AddAsync(exercise);
            _dbContext.SaveChanges();

            return exercise;
        }

        public async Task<bool> DeleteExerciseAsync(Guid exerciseId)
        {
            Exercise exercise = await _dbContext.Exercises.FindAsync(exerciseId);
            var result = _dbContext.Exercises.Remove(exercise);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<Exercise> FindExerciseByIdAsyns(Guid exerciseId)
        {
            Exercise exercise = await _dbContext.Exercises.FindAsync(exerciseId);
            if (exercise == null) { throw new ArgumentNullException("Nie znaleziono ćwiczenia o podanym id"); }
            return exercise;
        }

        public async Task<List<Exercise>> GetAllExercises(Guid trainerId)
        {
            List<Exercise> result = await _dbContext.Exercises.Where(temp => temp.TrainerId == trainerId).ToListAsync();
            return result;
        }

        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
        {
            Exercise updateExercise = await _dbContext.Exercises.FindAsync(exercise.ExerciseId);
            updateExercise.Name = exercise.Name;
            updateExercise.Description = exercise.Description;
            updateExercise.Sets = exercise.Sets;
            updateExercise.Repetitions = exercise.Repetitions;
            updateExercise.ExerciseDuration = exercise.ExerciseDuration;
            await _dbContext.SaveChangesAsync();
            return updateExercise;
        }
    }
}

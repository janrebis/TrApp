using Microsoft.IdentityModel.Tokens;
using TrApp.Models;
using TrApp.RepositoryContracts;
using TrApp.ServiceContracts;

namespace TrApp.Services
{
    public class ExerciseService : IExercieService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise> CreateExersiceAsync(Guid trainingPlanId, string name, string? description, int? sets, int? repetitions, int? weight, TimeSpan? exerciseDuration)
        {
            Exercise exercise = new Exercise
            {
                ExerciseId = Guid.NewGuid(),
                TrainingPlanId = trainingPlanId,
                Name = name,
                Description = description,
                Sets = sets,
                Repetitions = repetitions,
                Weight = weight,
                ExerciseDuration = exerciseDuration
            };

           await _exerciseRepository.AddExerciseAsync(exercise);
           return exercise;

        }

        public async Task<bool> DeleteExerciseAsyn(Guid exerciseId)
        {
            var result = await _exerciseRepository.DeleteExerciseAsync(exerciseId);
            return result;
        }
        public async Task<List<Exercise>> GetExerciseListAsync(Guid trainerId)
        {
            List<Exercise> exerciseList = await _exerciseRepository.GetAllExercises(trainerId);
            if(exerciseList == null)
            {
                throw new ArgumentNullException("Nie stworzono jeszcze żadnego ćwiczenia " + nameof(exerciseList));
            }
            return exerciseList;
        }

        public async Task<Exercise> UpdateExerciseAsyns(Guid exerciseId, string name, string? description, int? sets, int? repetitions, int? weight, TimeSpan? exerciseDuration)
        {
            Exercise exercise = await _exerciseRepository.FindExerciseByIdAsyns(exerciseId);
            exercise.Name = name;
            exercise.Description = description;
            exercise.Sets = sets;
            exercise.Repetitions = repetitions;
            exercise.Weight = weight;
            exercise.ExerciseDuration = exerciseDuration;

            await _exerciseRepository.UpdateExerciseAsync(exercise);
            return exercise;
        }
    }
}

using TrApp.Models;
using TrApp.RepositoryContracts;
using TrApp.ServiceContracts;

namespace TrApp.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly ITraineeRepository _traineeRepository;

        public TraineeService(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }
        public async Task<Trainee> CreateTraineeAsync(string name, int age, Guid trainerId)
        {
            if (trainerId == Guid.Empty) { throw new ArgumentException("Trainer id cannot be blank"); }
            if (name == null) { throw new ArgumentNullException("Name of trainne is required"); }

            Trainee trainee = new Trainee
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                CreatedAt = DateTime.Now,
                TrainerId = trainerId
            };

            await _traineeRepository.AddClientAsync(trainee);
            return trainee;
        }

        public async Task<bool> DeleteTraineeAsync(Guid traineeId)
        {
            var result = await _traineeRepository.DeleteClientAsync(traineeId);
            return result;
            
        }

        public async Task<Trainee> FindTraineeByIdAsync(Guid trainneId)
        {
            Trainee trainee = await _traineeRepository.GetClientByIdAsync(trainneId);
            return trainee;
        }

        public async Task<Trainee> UpdateTraineeAsync(Guid traineeId, string? name, int? age)
        {
            Trainee trainee = await _traineeRepository.GetClientByIdAsync(traineeId);

            if (trainee == null) { throw new ArgumentNullException("Podopieczny o tym identyfikatorze nie istnieje w bazie"); }
            if (name == null) { trainee.Name = name; }
            if (age == null) { trainee.Age = age; }
            
            Trainee updatedTrainee = await _traineeRepository.UpdateClientAsync(trainee);

            return updatedTrainee;
        }
    }
}

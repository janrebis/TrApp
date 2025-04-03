using TrApp.Models;

namespace TrApp.ServiceContracts
{
    public interface ITraineeService
    {
        public Task<Trainee> CreateTraineeAsync(string name, int age, Guid trainerid);
        public Task<Trainee> UpdateTraineeAsync(Guid traineeId, string? name, int? age);
        public Task<Trainee> FindTraineeByIdAsync(Guid traineeId);
        public Task<bool> DeleteTraineeAsync(Guid traineeId);
    }
}

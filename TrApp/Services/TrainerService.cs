using TrApp.Models;
using TrApp.RepositoryContracts;
using TrApp.ServiceContracts;

namespace TrApp.Services
{
    public class TrainerService : ITrainerService
       
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task<Trainer> CreateTrainerAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }
           
            Trainer? trainer = await _trainerRepository.FindTrainerById(id);

            if (trainer != null)
            {
                throw new ArgumentException("Given trainer already exists");
            }

           return await _trainerRepository.AddTrainerAsync(id);
        }

        public async Task<bool> DeleteTrenerAsync(Guid id)
        {
            var trainerExists = await _trainerRepository.FindTrainerById(id);
            if (trainerExists == null)
            {
                throw new ArgumentException($"Trener o ID {id} nie istnieje");
            }

            var deleteResult = await _trainerRepository.DeleteTrainerAsync(id);

            if (!deleteResult)
            {
                throw new InvalidOperationException($"Nie udało się usunąć trenera o ID: {id}");
            }

            return true;
        }

        public async Task<Trainer> FindTrainerByIdAsync(Guid id)
        {
            
           Trainer? trainer = await _trainerRepository.FindTrainerById(id);
            if (trainer == null)
            {
                throw new ArgumentException("Trainer with given Id does not exist");
            }

            return trainer;
        }
    }
}

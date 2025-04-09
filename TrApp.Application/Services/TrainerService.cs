using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.InterfaceRepositories;
using TrApp.Domain.ValueObjects;

namespace TrApp.Application.Services
{
    public class TrainerService
    {
        private readonly IAggregateRootRepository<Trainer> _trainerRepository;

        public TrainerService(IAggregateRootRepository<Trainer> trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        #region Trainer
        public async Task<Guid> AddTrainer(Guid trainerId, string name)
        {
            var trainer = new Trainer(trainerId, name);
            await _trainerRepository.InsertAsync(trainer);
            return trainer.TrainerId;
        }

        public async Task<Trainer> FindTrainerAsync(Guid trainerId)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            return trainer;
        }

        public async Task RemoveTrainerAsync(Guid trainerId)
        {
            await _trainerRepository.RemoveAsync(trainerId);

        }
        #endregion

        #region Trainee

        public async Task AddTraineeAsync(Guid trainerId, string name, int age)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            trainer.AddTrainee(name, age);
            await _trainerRepository.InsertAsync(trainer);

        }

        public async Task UpdateTraineeAsync(Guid trainerId, Guid traineeId, string name, int age)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            trainer.UpdateTrainee(traineeId, name, age);
            await _trainerRepository.UpdateAsync(trainer);
        }

        public async Task<IEnumerable<TraineeDto>> GetAllTraineesAsync(Guid trainerId)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            return trainer.GetAllTrainees();
        }

        public async Task<TraineeDto> GetTraineeByIdAsync(Guid trainerId, Guid traineeId)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            var traineeDto = trainer.GetTraineeData(traineeId);
            return traineeDto;
        }

        public async Task RemoveTraineeAsync(Guid trainerId, Guid traineeId)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            trainer.DeleteTrainee(traineeId);
            await _trainerRepository.RemoveAsync(trainerId);
        }
        #endregion
    }
}

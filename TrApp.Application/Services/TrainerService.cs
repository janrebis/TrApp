﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TrApp.Domain.Entities.AggregateRoots;
<<<<<<< HEAD
using TrApp.Domain.InterfaceRepositories;
using TrApp.Domain.ValueObjects;
=======
using TrApp.Domain.Entities.DTO;
using TrApp.Domain.InterfaceRepositories;
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4

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
<<<<<<< HEAD
            await _trainerRepository.InsertAsync(trainer);
=======
            await _trainerRepository.SaveAsync(trainer);
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4
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
<<<<<<< HEAD
            await _trainerRepository.InsertAsync(trainer);
=======
            await _trainerRepository.SaveAsync(trainer);
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4

        }

        public async Task UpdateTraineeAsync(Guid trainerId, Guid traineeId, string name, int age)
        {
            var trainer = await _trainerRepository.FindByIdAsync(trainerId);
            trainer.UpdateTrainee(traineeId, name, age);
<<<<<<< HEAD
            await _trainerRepository.UpdateAsync(trainer);
=======
            await _trainerRepository.SaveAsync(trainer);
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4
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
<<<<<<< HEAD
            await _trainerRepository.RemoveAsync(trainerId);
=======
            await _trainerRepository.SaveAsync(trainer);
>>>>>>> 879c5d964768c79cc6b804e81dc2b8f3ef9858b4
        }
        #endregion
    }
}

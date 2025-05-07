using Microsoft.EntityFrameworkCore;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Infrastructure.Persistence.Repositories;
using TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions;
using Xunit;

namespace TrApp.Infrastructure.Persistence.Tests
{
    public class TrainerRepositoryTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly TrainerRepository _trainerRepository;

        public TrainerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _trainerRepository = new TrainerRepository(_dbContext);
        }

        [Fact]
        public async Task FindByIdAsync_Should_ReturnTrainerWithTrainees_When_TrainerExists()
        {
            // Arrange
            var trainerId = Guid.NewGuid();
            var trainer = new Trainer(trainerId, "John Doe");
            trainer.AddTrainee("Jane", 25);
            _dbContext.Trainers.Add(trainer);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _trainerRepository.FindByIdAsync(trainerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trainerId, result.TrainerId);
            Assert.Equal("John Doe", result.Name);
            var traineeDto = result.GetTraineeData(result.Trainees.First().TraineeId);
            Assert.Equal("Jane", traineeDto.Name);
            Assert.Equal(25, traineeDto.Age);
        }

        [Fact]
        public async Task FindByIdAsync_Should_ThrowTrainerNotFoundException_When_TrainerDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<TrainerNotFoundException>(() =>
                _trainerRepository.FindByIdAsync(nonExistentId));
        }

        [Fact]
        public async Task SaveAsync_Should_PersistNewTrainerWithTrainees()
        {
            // Arrange
            var trainerId = Guid.NewGuid();
            var trainer = new Trainer(trainerId, "John Doe");
            trainer.AddTrainee("Jane", 25);

            // Act
            await _trainerRepository.InsertAsync(trainer);

            // Assert
            var savedTrainer = await _dbContext.Trainers
                .Include("_trainees")
                .FirstOrDefaultAsync(t => t.TrainerId == trainerId);
            Assert.NotNull(savedTrainer);
            Assert.Equal("John Doe", savedTrainer.Name);
            var traineeDto = savedTrainer.GetTraineeData(savedTrainer.Trainees.First().TraineeId);
            Assert.Equal("Jane", traineeDto.Name);
            Assert.Equal(25, traineeDto.Age);
        }

        [Fact]
        public async Task RemoveAsync_Should_DeleteTrainerAndTrainees_When_TrainerExists()
        {
            // Arrange
            var trainerId = Guid.NewGuid();
            var trainer = new Trainer(trainerId, "John Doe");
            trainer.AddTrainee("Jane", 25);
            _dbContext.Trainers.Add(trainer);
            await _dbContext.SaveChangesAsync();

            // Act
            await _trainerRepository.RemoveAsync(trainerId);

            // Assert
            var deletedTrainer = await _dbContext.Trainers
                .FirstOrDefaultAsync(t => t.TrainerId == trainerId);
            Assert.Null(deletedTrainer);
        }

        [Fact]
        public async Task RemoveAsync_Should_ThrowTrainerNotFoundException_When_TrainerDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<TrainerNotFoundException>(() =>
                _trainerRepository.RemoveAsync(nonExistentId));
        }
    }
}
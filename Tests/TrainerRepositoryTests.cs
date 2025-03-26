using AutoFixture;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using TrApp.Identity;
using TrApp.Models;
using TrApp.Repository;
using TrApp.RepositoryContracts;
using TrApp.ServiceContracts;
using TrApp.Services;

namespace Tests
{
    public class TrainerRepositoryTests
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly ITrainerService _trainerService;
        private readonly IFixture _fixture;

        public TrainerRepositoryTests()
        {
            _fixture = new Fixture();
            var trainersInitialData = new List<Trainer>();
            DbContextMock<ApplicationDbContext> dbContextMock
                = new DbContextMock<ApplicationDbContext>(new DbContextOptionsBuilder<ApplicationDbContext>().Options);

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Trainers, trainersInitialData);

            _trainerRepository = new TrainerRepository(dbContext);
            _trainerService = new TrainerService(_trainerRepository);
        }

        [Fact]
        public async Task createNewTrainer_ArgumentNullException()
        {
            Guid testId = Guid.Empty;

            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _trainerService.CreateTrainerAsync(testId)
            );
        }

        [Fact]
        public async Task createNewTrainer_DuplicatedIdArgumentException()
        {
            Guid testId = Guid.NewGuid();
            await _trainerService.CreateTrainerAsync(testId);
            
           await Assert.ThrowsAsync<ArgumentException>(async () =>

            await _trainerService.CreateTrainerAsync(testId)

            );
        }

        [Fact]
        public async Task CreateNewTrainer_WithValidId_ShouldCreateAndFindTrainer()
        {
            Guid testId = Guid.NewGuid();
            await _trainerService.CreateTrainerAsync(testId);

            Trainer trainer = await _trainerService.FindTrainerByIdAsync(testId);

            Assert.NotNull(trainer);
            Assert.Equal(trainer.Id, testId);
        }

        [Fact]
        public async Task DeleteTrainer_WithId_ShouldReturnArgumentException()
        {
            Guid id = Guid.NewGuid();

            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _trainerService.DeleteTrenerAsync(id));
        }

        [Fact]
        public async Task DeleteTrainer_WithId_ShouldDeleteTrainer()
        {
            Guid id = Guid.NewGuid();
            Trainer trainer = await _trainerService.CreateTrainerAsync(id);
            var result = await _trainerService.DeleteTrenerAsync(trainer.Id);
            Assert.True(result);
            await Assert.ThrowsAsync<ArgumentException>(async () =>await  _trainerService.FindTrainerByIdAsync(trainer.Id));
        }
    }
}

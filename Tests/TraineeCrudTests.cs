using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class TraineeCrudTests
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly ITrainerService _trainerService;
        private readonly ITraineeRepository _traineeRepository;
        private readonly ITraineeService _traineeService;
        private readonly IFixture _fixture;

        public TraineeCrudTests()
        {
            _fixture = new Fixture();
            var traineesInitialData = new List<Trainee>();
            DbContextMock<ApplicationDbContext> dbContextMock
                = new DbContextMock<ApplicationDbContext>(new DbContextOptionsBuilder<ApplicationDbContext>().Options);

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Trainees, traineesInitialData);

            _traineeRepository = new TraineeRepository(dbContext);
            _traineeService = new TraineeService(_traineeRepository);
        }


        [Fact]
        public async Task CreateNewTrainee_EmptyGuid_ArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _traineeService.CreateTraineeAsync("John", 15, Guid.Empty)
            );
        }
        [Fact]
        public async Task CreateNewTrainee_NullName_ArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _traineeService.CreateTraineeAsync(null, 15, Guid.NewGuid())
            );
        }

        [Fact]
        public async Task CreateNewTrainee_Success()
        {
        Guid id = Guid.NewGuid();
          var result = await _traineeService.CreateTraineeAsync("jeden", 19, id);
          var expected = await _traineeService.FindTraineeByIdAsync(result.Id);
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }
    }

}

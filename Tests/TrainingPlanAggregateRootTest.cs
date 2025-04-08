using System;
using Xunit;
using TrApp.Domain.Entities.AggregateRoots;
using TrApp.Domain.Entities.Enum;
using TrApp.Domain.Exception;
using TrApp.Domain.ValueObjects;
using TrApp.Models.Enum;

namespace TrApp.Tests.AggregateRoots
{
    public class TrainingPlanTests
    {
        [Fact]
        public void Constructor_WithValidName_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "Strength Training";

            // Act
            var trainingPlan = new TrainingPlan(name);

            // Assert
            Assert.NotEqual(Guid.Empty, trainingPlan.TrainingPlanId);
            Assert.Equal(name, trainingPlan.Name);
            Assert.Equal(TrainingPlanStatus.ACTIVE, trainingPlan.Status);
            Assert.True(DateTime.UtcNow - trainingPlan.CreationDate < TimeSpan.FromSeconds(1));
            Assert.Null(trainingPlan.ScheduledDate);
            Assert.Null(trainingPlan.Notes);
            Assert.Empty(trainingPlan.Exercises);
        }

        [Fact]
        public void Constructor_WithEmptyName_SetsDefaultName()
        {
            // Arrange
            string name = "";

            // Act
            var trainingPlan = new TrainingPlan(name);

            // Assert
            Assert.Equal("Training Plan", trainingPlan.Name);
            Assert.Equal(TrainingPlanStatus.ACTIVE, trainingPlan.Status);
        }

        [Fact]
        public void AddExercise_WithValidData_AddsExerciseToCollection()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exerciseData = new ExerciseData
            {
                Name = "Push-up",
                Description = "Basic push-up",
                Sets = 3,
                Repetitions = 15,
                ExerciseDuration = TimeSpan.FromMinutes(2),
                Weight = 0,
                WeightUnit = WeightUnit.KG
            };

            // Act
            trainingPlan.AddExercise(exerciseData);

            // Assert
            Assert.Single(trainingPlan.Exercises);
            var exercise = trainingPlan.Exercises.First();
            Assert.Equal("Push-up", exercise.Name);
            Assert.Equal("Basic push-up", exercise.Description);
            Assert.Equal(3, exercise.Sets);
            Assert.Equal(15, exercise.Repetitions);
            Assert.Equal(TimeSpan.FromMinutes(2), exercise.ExerciseDuration);
            Assert.Equal(0, exercise.Weight);
            Assert.Equal(WeightUnit.KG, exercise.WeightUnit);
        }

        [Fact]
        public void AddExercise_WithNullData_ThrowsArgumentNullException()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => trainingPlan.AddExercise(null));
            Assert.Equal("data", exception.ParamName);
        }

        [Fact]
        public void AddExercise_WithEmptyName_ThrowsArgumentException()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exerciseData = new ExerciseData
            {
                Name = "",
                Sets = 3,
                Repetitions = 15
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => trainingPlan.AddExercise(exerciseData));
        }

        [Fact]
        public void UpdateExercise_WithValidData_UpdatesExercise()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exerciseData = new ExerciseData { Name = "Squat", Sets = 4, Repetitions = 10 };
            trainingPlan.AddExercise(exerciseData);
            var exerciseId = trainingPlan.Exercises.First().ExerciseId;
            var updatedData = new ExerciseData
            {
                Name = "Squat Updated",
                Description = "Updated squat",
                Sets = 5,
                Repetitions = 12
            };

            // Act
            trainingPlan.UpdateExercise(exerciseId, updatedData);

            // Assert
            var exercise = trainingPlan.Exercises.First();
            Assert.Equal("Updated squat", exercise.Description);
            Assert.Equal(5, exercise.Sets);
            Assert.Equal(12, exercise.Repetitions);
        }

        [Fact]
        public void UpdateExercise_WithNonExistentId_ThrowsExerciseNotFoundException()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exerciseData = new ExerciseData { Name = "Squat" };

            // Act & Assert
            Assert.Throws<ExerciseNotFoundException>(() => trainingPlan.UpdateExercise(Guid.NewGuid(), exerciseData));
        }

        [Fact]
        public void DeleteExercise_WithExistingId_RemovesExercise()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exerciseData = new ExerciseData { Name = "Bench Press" };
            trainingPlan.AddExercise(exerciseData);
            var exerciseId = trainingPlan.Exercises.First().ExerciseId;

            // Act
            trainingPlan.DeleteExercise(exerciseId);

            // Assert
            Assert.Empty(trainingPlan.Exercises);
        }

        [Fact]
        public void DeleteExercise_WithNonExistentId_ThrowsExerciseNotFoundException()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");

            // Act & Assert
            Assert.Throws<ExerciseNotFoundException>(() => trainingPlan.DeleteExercise(Guid.NewGuid()));
        }

        [Fact]
        public void Schedule_WithValidDate_SetsScheduledDate()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var scheduledDate = DateTime.UtcNow.AddDays(1);

            // Act
            trainingPlan.Schedule(scheduledDate);

            // Assert
            Assert.Equal(scheduledDate, trainingPlan.ScheduledDate);
        }

        [Fact]
        public void Schedule_WithDateBeforeCreation_ThrowsArgumentException()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var invalidDate = trainingPlan.CreationDate.AddDays(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => trainingPlan.Schedule(invalidDate));
            Assert.Equal("Scheduled date cannot be earlier than creation date", exception.Message);
        }

        [Fact]
        public void TotalDuration_WithMultipleExercises_ReturnsSum()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            var exercise1 = new ExerciseData { Name = "Exercise 1", ExerciseDuration = TimeSpan.FromMinutes(5) };
            var exercise2 = new ExerciseData { Name = "Exercise 2", ExerciseDuration = TimeSpan.FromMinutes(10) };
            trainingPlan.AddExercise(exercise1);
            trainingPlan.AddExercise(exercise2);

            // Act
            var totalDuration = trainingPlan.TotalDuration;

            // Assert
            Assert.Equal(TimeSpan.FromMinutes(15), totalDuration);
        }

        [Fact]
        public void TotalDuration_WithNoExercises_ReturnsZero()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");

            // Act
            var totalDuration = trainingPlan.TotalDuration;

            // Assert
            Assert.Equal(TimeSpan.Zero, totalDuration);
        }

        [Fact]
        public void ChangeStatus_WithValidStatus_UpdatesStatus()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");

            // Act
            trainingPlan.ChangeStatus(TrainingPlanStatus.COMPLETED);

            // Assert
            Assert.Equal(TrainingPlanStatus.COMPLETED, trainingPlan.Status);
        }

        [Fact]
        public void UpdateNotes_WithValidNotes_UpdatesNotes()
        {
            // Arrange
            var trainingPlan = new TrainingPlan("Test Plan");
            string notes = "Updated notes";

            // Act
            trainingPlan.UpdateNotes(notes);

            // Assert
            Assert.Equal(notes, trainingPlan.Notes);
        }
    }
}
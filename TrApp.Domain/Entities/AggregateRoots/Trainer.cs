using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using TrApp.Domain.Entities.DTO;
using TrApp.Domain.Entities.Validators;
using TrApp.Domain.Exception;
using TrApp.Domain.ValueObjects;
using TrApp.Models;



namespace TrApp.Domain.Entities.AggregateRoots
{
    public class Trainer : IAggregateRoot
    {
        [Key]
        public Guid TrainerId { get; private set; }
        public string Name { get; private set; }
        private readonly List<Trainee> _trainees = new List<Trainee>(); //od .net9 może być new();
        public IReadOnlyCollection<Trainee> Trainees => _trainees.AsReadOnly();

        public Trainer(Guid trainerId, string name)
        {
            TrainerId = trainerId;
            Name = name;
        }

        public void AddTrainee(string name, int age)
        {
            TraineeValidator.ValidateTraineeNameAndAge(name, age);
            if (_trainees.Count >= 10) { throw new MaximumTraineesValueException(); }
            Trainee trainee = new Trainee(name, age);
            _trainees.Add(trainee);
        }

        public void UpdateTrainee(Guid traineeId, string name, int age)
        {
            var traineeToUpdate = GetTraineeById(traineeId);
            TraineeValidator.ValidateTraineeNameAndAge(name, age);
            traineeToUpdate.Update(name, age);
        }

        public void DeleteTrainee(Guid traineeId)
        {
            var traineeToDelete = GetTraineeById(traineeId);
            _trainees.Remove(traineeToDelete);
        }

        public TraineeDto GetTraineeData(Guid traineeId)
        {
            var trainee = GetTraineeById(traineeId);
            TraineeDto traineeDto = new TraineeDto(traineeId, trainee.Name, trainee.Age);
            return traineeDto;
        }

        private Trainee GetTraineeById(Guid traineeId)
        {
            var trainee = _trainees.FirstOrDefault(temp => temp.TraineeId == traineeId);
            if (trainee == null) throw new InvalidOperationException("Trainee not found.");
            return trainee;
        }

        public IEnumerable<TraineeDto> GetAllTrainees()
        {
            return _trainees.Select(t => new TraineeDto(t.TraineeId, t.Name, t.Age));
        }

    }
}